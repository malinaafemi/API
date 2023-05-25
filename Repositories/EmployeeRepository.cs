using API.Contexts;
using API.Model;
using API.Contracts;
using API.ViewModels.Universities;

namespace API.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BookingManagementDbContext context) : base(context) { }


        public int CreateWithValidate(Employee employee)
        {
            try 
            { 
                bool ExistsByEmail = _context.Employees.Any(e => e.Email == employee.Email);
                if (ExistsByEmail)
                {
                    return 1;
                }

                bool ExistsByPhoneNumber = _context.Employees.Any(e => e.PhoneNumber == employee.PhoneNumber);
                if (ExistsByPhoneNumber)
                {
                    return 2;
                }
                
                Create(employee);
                return 3;

            } catch 
            {
                return 0;
            }
        }

    }
}
