using API.Contracts;
using API.Model;
using API.Repositories;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Others;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountRoleController : BaseController<AccountRole, AccountRoleVM>
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMapper<AccountRole, AccountRoleVM> _accounRoleMapper;
        public AccountRoleController(IAccountRoleRepository accountRoleRepository, IMapper<AccountRole, AccountRoleVM> accountRoleMapper) : base(accountRoleRepository, accountRoleMapper)
        {
            _accountRoleRepository = accountRoleRepository;
            _accounRoleMapper = accountRoleMapper;
        }

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var accountroles = _accountRoleRepository.GetAll();
            if (!accountroles.Any())
            {
                return NotFound(new ResponseVM<List<AccountRoleVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }
            var data = accountroles.Select(_accounRoleMapper.Map).ToList();

            return Ok(new ResponseVM<List<AccountRoleVM>>
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
            var accountrole = _accountRoleRepository.GetByGuid(guid);
            if (accountrole is null)
            {
                return NotFound(new ResponseVM<AccountRoleVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = _accounRoleMapper.Map(accountrole);

            return Ok(new ResponseVM<AccountRoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(AccountRoleVM accountRoleVM)
        {
            var accountRoleConverted = _accounRoleMapper.Map(accountRoleVM);

            var result = _accountRoleRepository.Create(accountRoleConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<AccountRoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _accounRoleMapper.Map(result);
            return Ok(new ResponseVM<AccountRoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }

        [HttpPut]
        public IActionResult Update(AccountRoleVM accountRoleVM)
        {
            var accountRoleConverted = _accounRoleMapper.Map(accountRoleVM);
            var isUpdated = _accountRoleRepository.Update(accountRoleConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<AccountRoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _accounRoleMapper.Map(accountRoleConverted);
            return Ok(new ResponseVM<AccountRoleVM>
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
            var isDeleted = _accountRoleRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<AccountRoleVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<AccountRoleVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }*/
    }
}
