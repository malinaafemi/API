using API.Contracts;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using API.ViewModels.Educations;
using API.Utility;
using API.ViewModels.Universities;
using API.ViewModels.Accounts;
using API.ViewModels.Others;
using System.Net;
using API.ViewModels.AccountRoles;
using API.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : BaseController<Education, EducationVM>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper<Education, EducationVM> _educationMapper;
        public EducationController(IEducationRepository educationRepository, IMapper<Education, EducationVM> educationMapper) : base(educationRepository, educationMapper)
        {
            _educationRepository = educationRepository;
            _educationMapper = educationMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var educations = _educationRepository.GetAll();
            if (!educations.Any())
            {
                return NotFound(new ResponseVM<List<EducationVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }
            var data = educations.Select(_educationMapper.Map).ToList();
            //var resultConverted = educations.Select(EducationVM.ToVM);

            return Ok(new ResponseVM<List<EducationVM>>
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
            var education = _educationRepository.GetByGuid(guid);
            if (education is null)
            {
                return NotFound(new ResponseVM<EducationVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = _educationMapper.Map(education);

            return Ok(new ResponseVM<EducationVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(EducationVM educationVM)
        {
            var educationConverted = _educationMapper.Map(educationVM);

            var result = _educationRepository.Create(educationConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<EducationVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _educationMapper.Map(result);
            return Ok(new ResponseVM<EducationVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }

        [HttpPut]
        public IActionResult Update(EducationVM educationVM)
        {
            var educationConverted = _educationMapper.Map(educationVM);
            var isUpdated = _educationRepository.Update(educationConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<EducationVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _educationMapper.Map(educationConverted);
            return Ok(new ResponseVM<EducationVM>
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
            var isDeleted = _educationRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<EducationVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<EducationVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }

    }
}
