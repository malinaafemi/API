using API.Contracts;
using API.Model;
using API.Repositories;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Others;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UniversityController : BaseController<University, UniversityVM>
{
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IMapper<University, UniversityVM> _mapper;
    private readonly IMapper<Education, EducationVM> _educationMapper;
    public UniversityController(IUniversityRepository universityRepository, IEducationRepository educationRepository, IMapper<University, UniversityVM> mapper,IMapper<Education, EducationVM> educationMapper) : base(universityRepository, mapper)
    {
        _universityRepository = universityRepository;
        _educationRepository = educationRepository;
        _mapper = mapper;
        _educationMapper = educationMapper;
    }

    [HttpGet("WithEducation")]
    public IActionResult GetAllWithEducation()
    {
        var universities = _universityRepository.GetAll();
        if (!universities.Any())
        {
            return NotFound(new ResponseVM<List<UniversityVM>>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data not found"
            });
        }

        var results = new List<UniversityEducationVM>();
        foreach (var university in universities)
        {
            var education = _educationRepository.GetByUniversityId(university.Guid);
            //var educationMapped = education.Select(EducationVM.ToVM);
            var educationMapped = education.Select(_educationMapper.Map);

            var result = new UniversityEducationVM
            {
                Guid = university.Guid,
                Code = university.Code,
                Name = university.Name,
                Educations = educationMapped
            };

            results.Add(result);
        }
        return Ok(new ResponseVM<List<UniversityEducationVM>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Get data succeed",
            Data = results
        });
    }

   /* [HttpGet]
    public IActionResult GetAll()
    {
        var universities = _universityRepository.GetAll();
        if (!universities.Any())
        {
            return NotFound(new ResponseVM<List<UniversityVM>>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data not found"
            });
        }

        var data = universities.Select(_mapper.Map).ToList();

        return Ok(new ResponseVM<List<UniversityVM>>
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
        var university = _universityRepository.GetByGuid(guid);
        if (university is null)
        {
            return NotFound(new ResponseVM<UniversityVM>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data not found"
            });
        }

        var data = _mapper.Map(university);

        return Ok(new ResponseVM<UniversityVM>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Get data succeed",
            Data = data
        });
    }

    [HttpPost]
    public IActionResult Create(UniversityVM universityVM)
    {
        // var universityConverted = UniversityVM.ToModel(universityVM);
        var universityConverted = _mapper.Map(universityVM);

        var result = _universityRepository.Create(universityConverted);
        if (result is null)
        {
            return BadRequest(new ResponseVM<UniversityVM>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Create failed"
            });
        }

        var resultConverted = _mapper.Map(result);
        return Ok(new ResponseVM<UniversityVM>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Create success",
            Data = resultConverted
        });
    }

    [HttpPut]
    public IActionResult Update(UniversityVM universityVM)
    {
        var universityConverted = _mapper.Map(universityVM);
        var isUpdated = _universityRepository.Update(universityConverted);
        if (!isUpdated)
        {
            return BadRequest(new ResponseVM<UniversityVM>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Update failed"
            });
        }

        var data = _mapper.Map(universityConverted);
        return Ok(new ResponseVM<UniversityVM>
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
        var isDeleted = _universityRepository.Delete(guid);
        if (!isDeleted)
        {
            return BadRequest(new ResponseVM<UniversityVM>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Delete failed"
            });
        }

        return Ok(new ResponseVM<UniversityVM>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }*/
}