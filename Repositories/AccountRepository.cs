using API.Contexts;
using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.Accounts;
using API.ViewModels.Universities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Repositories;

public class AccountRepository : GeneralRepository<Account>, IAccountRepository
{
    
    public AccountRepository(
        BookingManagementDbContext context,
        IUniversityRepository universityRepository,
        IEmployeeRepository employeeRepository,
        IEducationRepository educationRepository,
        IAccountRoleRepository accountRoleRepository,
        IRoleRepository roleRepository
    ) : base(context)
    {
        _universityRepository = universityRepository;
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
        
    }

    private readonly IUniversityRepository _universityRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    

    // coba

    public int Register(RegisterVM registerVM)
    {
        try 
        {
            var university = new University
            {
                Code = registerVM.UniversityCode,
                Name = registerVM.UniversityName

            };
            _universityRepository.CreateWithValidate(university);

            var employee = new Employee
            {
                NIK = GenerateNIK(),
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                HiringDate = registerVM.HiringDate,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            _employeeRepository.Create(employee);

            var education = new Education
            {
                Guid = employee.Guid,
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityGuid = university.Guid
            };
            _educationRepository.Create(education);

            var hashedPassword = Hashing.HashPassword(registerVM.Password);
            var account = new Account
            {
                Guid = employee.Guid,
                Password = hashedPassword,
                IsDeleted = false,
                IsUsed = true,
                OTP = 0
            };

            Create(account);

            var accountRole = new AccountRole
            {
                AccountGuid = employee.Guid,
                RoleGuid = Guid.Parse("2483b7c6-10bd-4ee4-69d9-08db60bf2967")
            };
            _context.AccountRoles.Add(accountRole);
            _context.SaveChanges();

            return 3;

        } catch
        {
            return 0;
        }

    }

    private string GenerateNIK()
    {
        var lastNik = _employeeRepository.GetAll().OrderByDescending(e => int.Parse(e.NIK)).FirstOrDefault();

        if (lastNik != null)
        {
            int lastNikNumber;
            if (int.TryParse(lastNik.NIK, out lastNikNumber))
            {
                return (lastNikNumber+1).ToString();
            }
        }

        return "000001";
    }

    public LoginVM Login(LoginVM loginVM)
    {
        var account = GetAll();
        var employee = _employeeRepository.GetAll();
        var query = from emp in employee
                    join acc in account
                    on emp.Guid equals acc.Guid
                    where emp.Email == loginVM.Email
                    select new LoginVM
                    {
                        Email = emp.Email,
                        Password = acc.Password

                    };
        return query.FirstOrDefault();
    }

    public int ChangePasswordAccount(Guid? employeeId, ChangePasswordVM changePasswordVM)
    {
        var account = new Account();
        account = _context.Set<Account>().FirstOrDefault(a => a.Guid == employeeId);
        if (account == null || account.OTP != changePasswordVM.OTP)
        {
            return 2;
        }
        // Cek apakah OTP sudah digunakan
        if (account.IsUsed)
        {
            return 3;
        }
        // Cek apakah OTP sudah expired
        if (account.ExpiredTime < DateTime.Now)
        {
            return 4;
        }
        // Cek apakah NewPassword dan ConfirmPassword sesuai
        if (changePasswordVM.NewPassword != changePasswordVM.ConfirmPassword)
        {
            return 5;
        }
        // Update password
        var hashedPassword = Hashing.HashPassword(changePasswordVM.NewPassword);
        //account.Password = changePasswordVM.NewPassword;
        account.Password = hashedPassword;
        account.IsUsed = true;
        try
        {
            var updatePassword = Update(account);
            if (!updatePassword)
            {
                return 0;
            }
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public int UpdateOTP(Guid? employeeId)
    {
        var account = new Account();
        account = _context.Set<Account>().FirstOrDefault(a => a.Guid == employeeId);
        //Generate OTP
        Random rnd = new Random();
        var getOtp = rnd.Next(100000, 999999);
        account.OTP = getOtp;

        //Add 5 minutes to expired time
        account.ExpiredTime = DateTime.Now.AddMinutes(5);
        account.IsUsed = false;
        try
        {
            var check = Update(account);

            if (!check)
            {
                return 0;
            }
            return getOtp;
        }
        catch
        {
            return 0;
        }
    }

    public IEnumerable<string> GetRoles(Guid guid)
    {
        var getAccount = GetByGuid(guid);
        if (getAccount == null) return Enumerable.Empty<string>();

        var getAccountRoles = from accountRoles in _context.AccountRoles
                              join roles in _context.Roles on accountRoles.RoleGuid equals roles.Guid
                              where accountRoles.AccountGuid == guid
                              select roles.Name;

        return getAccountRoles.ToList();
        
    }

}
