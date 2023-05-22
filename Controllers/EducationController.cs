using API.Contracts;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using API.ViewModels.Educations;
using API.Utility;
using API.ViewModels.Universities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper<Education, EducationVM> _educationMapper;
        public EducationController(IEducationRepository educationRepository, IMapper<Education, EducationVM> educationMapper)
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
                return NotFound();
            }
            var data = educations.Select(_educationMapper.Map).ToList();
            //var resultConverted = educations.Select(EducationVM.ToVM);

            return Ok(data);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var education = _educationRepository.GetByGuid(guid);
            if (education is null)
            {
                return NotFound();
            }

            var data = _educationMapper.Map(education);

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(EducationVM educationVM)
        {
            var educationConverted = _educationMapper.Map(educationVM);

            var result = _educationRepository.Create(educationConverted);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(EducationVM educationVM)
        {
            var educationConverted = _educationMapper.Map(educationVM);
            var isUpdated = _educationRepository.Update(educationConverted);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _educationRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
