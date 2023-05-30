using API.Contracts;
using API.Model;
using API.Repositories;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Others;
using API.ViewModels.Roles;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : BaseController<Role, RoleVM>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper<Role, RoleVM> _roleMapper;
        public RoleController(IRoleRepository roleRepository, IMapper<Role, RoleVM> roleMapper) : base(roleRepository, roleMapper)
        {
            _roleRepository = roleRepository;
            _roleMapper = roleMapper;
        }

    }
}
