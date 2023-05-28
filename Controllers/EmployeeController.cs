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

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeRepository.GetAll();
            if (!employees.Any())
            {
                return NotFound(new ResponseVM<List<EmployeeVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = employees.Select(_employeeMapper.Map).ToList();

            return Ok(new ResponseVM<List<EmployeeVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee is null)
            {
                return NotFound(new ResponseVM<EmployeeVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }
            var data = _employeeMapper.Map(employee);

            return Ok(new ResponseVM<EmployeeVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            var employeeConverted = _employeeMapper.Map(employeeVM);
            var result = _employeeRepository.Create(employeeConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<EmployeeVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });

            }

            var resultConverted = _employeeMapper.Map(result);
            return Ok(new ResponseVM<EmployeeVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }


        [HttpPut]
        public IActionResult Update(EmployeeVM employeeVM)
        {
            var employeeConverted = _employeeMapper.Map(employeeVM);
            var isUpdated = _employeeRepository.Update(employeeConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<EmployeeVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _employeeMapper.Map(employeeConverted);
            return Ok(new ResponseVM<EmployeeVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update success",
                Data = data
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _employeeRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<EmployeeVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<EmployeeVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
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
        }*/


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
