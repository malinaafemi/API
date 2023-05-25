using API.Contexts;
using API.Contracts;
using API.Model;
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
        IEducationRepository educationRepository
    ) : base(context)
    {
        _universityRepository = universityRepository;
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
    }

    private readonly IUniversityRepository _universityRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEducationRepository _educationRepository;
    

    // coba

    public int Register(RegisterVM registerVM)
    {
        try 
        {
            var university = new University
            {
                Code = registerVM.Code,
                Name = registerVM.Name

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
            var result = _employeeRepository.CreateWithValidate(employee);

            if(result != 3)
            {
                return result;
            }

            var education = new Education
            {
                Guid = employee.Guid,
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityGuid = university.Guid
            };
            _educationRepository.Create(education);

            var account = new Account
            {
                Guid = employee.Guid,
                Password = registerVM.Password,
                IsDeleted = false,
                IsUsed = true,
                OTP = 0
            };

            Create(account);

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

        return "100000";
    }

}
