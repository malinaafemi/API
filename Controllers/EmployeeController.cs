using API.Contracts;
using API.Model;
using API.Repositories;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Employees;
using API.ViewModels.Others;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : BaseController<Employee, EmployeeVM>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper<Employee, EmployeeVM> _employeeMapper;
        private readonly IMapper<Account, AccountVM> _accountMapper;
        private readonly IMapper<Education, EducationVM> _educationMapper;
        private readonly IMapper<University, UniversityVM> _universityMapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IAccountRepository accountRepository, IMapper<Employee, EmployeeVM> employeeMapper, 
            IMapper<Education, EducationVM> educationMapper, IMapper<University, UniversityVM> universityMapper,
            IMapper<Account, AccountVM> accountMapper) : base(employeeRepository, employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
            _educationMapper = educationMapper;
            _universityMapper = universityMapper;
            _accountMapper = accountMapper;

        }

        [HttpGet("GetAllMasterEmployee")]
        public IActionResult GetAllMasterEmployee()
        {
            var masterEmployees = _employeeRepository.GetAllMasterEmployee();
            if (!masterEmployees.Any())
            {
                return NotFound(new ResponseVM<List<MasterEmployeeVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Not Found"
                });
            }

            return Ok(new ResponseVM<IEnumerable<MasterEmployeeVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data ditampilkan",
                Data = masterEmployees
            });
        }


        [HttpGet("GetMasterEmployeeByGuid")]
        public IActionResult GetMasterEmployeeByGuid(Guid guid)
        {
            var masterEmployees = _employeeRepository.GetMasterEmployeeByGuid(guid);
            if (masterEmployees is null)
            {
                return NotFound(new ResponseVM<MasterEmployeeVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Not Found"
                });
            }

            return Ok(new ResponseVM<MasterEmployeeVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Found",
                Data = masterEmployees
            });
        }
    }
}
