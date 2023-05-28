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

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleRepository.GetAll();
            if (!roles.Any())
            {
                return NotFound(new ResponseVM<List<RoleVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = roles.Select(_roleMapper.Map).ToList();

            return Ok(new ResponseVM<List<RoleVM>>
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
            var role = _roleRepository.GetByGuid(guid);
            if (role is null)
            {
                return NotFound(new ResponseVM<RoleVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = _roleMapper.Map(role);

            return Ok(new ResponseVM<RoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(RoleVM roleVM)
        {
            var roleConverted = _roleMapper.Map(roleVM);

            var result = _roleRepository.Create(roleConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<RoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _roleMapper.Map(result);
            return Ok(new ResponseVM<RoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }

        [HttpPut]
        public IActionResult Update(RoleVM roleVM)
        {
            var roleConverted = _roleMapper.Map(roleVM);
            var isUpdated = _roleRepository.Update(roleConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<RoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _roleMapper.Map(roleConverted);
            return Ok(new ResponseVM<RoleVM>
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
            var isDeleted = _roleRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<RoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<RoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }*/

    }
}
