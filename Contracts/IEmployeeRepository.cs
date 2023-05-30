using API.Model;
using API.ViewModels.Employees;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        //int CreateWithValidate(Employee employee);
        public Guid? FindGuidByEmail(string email);

        IEnumerable<MasterEmployeeVM> GetAllMasterEmployee();

        MasterEmployeeVM? GetMasterEmployeeByGuid(Guid guid);

        bool CheckEmailAndPhoneAndNik(string value);

        Employee? GetByEmail(string email);
    }
}
