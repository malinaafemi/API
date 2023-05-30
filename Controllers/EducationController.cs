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

    }
}
