﻿using API.Contexts;
using API.Model;
using API.Contracts;
using API.ViewModels.Universities;
using API.ViewModels.Employees;

namespace API.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BookingManagementDbContext context) : base(context) { }

        public bool CheckEmailAndPhoneAndNik(string value)
        {
            return _context.Employees.Any(e => e.Email == value || e.PhoneNumber == value || e.NIK == value);
        }

        public Guid? FindGuidByEmail(string email)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
                if (employee == null)
                {
                    return null;
                }
                return employee.Guid;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<MasterEmployeeVM> GetAllMasterEmployee()
        {
            var employees = GetAll();
            var educations = _context.Educations.ToList();
            var universities = _context.Universities.ToList();

            var employeeEducations = new List<MasterEmployeeVM>();

            foreach (var employee in employees)
            {
                var education = educations.FirstOrDefault(e => e.Guid == employee?.Guid);
                var university = universities.FirstOrDefault(u => u.Guid == education?.UniversityGuid);

                if (education != null && university != null)
                {
                    var employeeEducation = new MasterEmployeeVM
                    {
                        Guid = employee.Guid,
                        NIK = employee.NIK,
                        FullName = employee.FirstName + " " + employee.LastName,
                        BirthDate = employee.BirthDate,
                        Gender = employee.Gender.ToString(),
                        HiringDate = employee.HiringDate,
                        Email = employee.Email,
                        PhoneNumber = employee.PhoneNumber,
                        Major = education.Major,
                        Degree = education.Degree,
                        GPA = education.GPA,
                        UniversityName = university.Name
                    };

                    employeeEducations.Add(employeeEducation);
                }
            }

            return employeeEducations;
        }

        MasterEmployeeVM? IEmployeeRepository.GetMasterEmployeeByGuid(Guid guid)
        {
            var employee = GetByGuid(guid);
            var education = _context.Educations.FirstOrDefault(e => e.Guid == guid);
            var university = _context.Universities.FirstOrDefault(u => u.Guid == education.UniversityGuid);

            var data = new MasterEmployeeVM
            {
                Guid = employee.Guid,
                NIK = employee.NIK,
                FullName = employee.FirstName + " " + employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender.ToString(),
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Major = education.Major,
                Degree = education.Degree,
                GPA = education.GPA,
                UniversityName = university.Name
            };

            return data;
        }

        public Employee? GetByEmail(string email)
        {
            var item = _context.Set<Employee>().FirstOrDefault(e=> e.Email == email);
            _context.ChangeTracker.Clear();
            return item;
        }

    }
}
