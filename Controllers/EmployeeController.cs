using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.Educations;
using API.ViewModels.Employees;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper<Employee, EmployeeVM> _employeeMapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper<University, UniversityVM> mapper, IMapper<Employee, EmployeeVM> employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeRepository.GetAll();
            if (!employees.Any())
            {
                return NotFound();
            }

            var data = employees.Select(_employeeMapper.Map).ToList();

            return Ok(data);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee is null)
            {
                return NotFound();
            }
            var data = _employeeMapper.Map(employee);

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            var employeeConverted = _employeeMapper.Map(employeeVM);
            var result = _employeeRepository.Create(employeeConverted);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(EmployeeVM employeeVM)
        {
            var employeeConverted = _employeeMapper.Map(employeeVM);
            var isUpdated = _employeeRepository.Update(employeeConverted);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _employeeRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
