using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Educations;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IMapper<AccountRole, AccountRoleVM> _accounRoleMapper;
        public AccountRoleController(IAccountRoleRepository accountRoleRepository, IMapper<AccountRole, AccountRoleVM> accountRoleMapper)
        {
            _accountRoleRepository = accountRoleRepository;
            _accounRoleMapper = accountRoleMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var accountroles = _accountRoleRepository.GetAll();
            if (!accountroles.Any())
            {
                return NotFound();
            }
            var data = accountroles.Select(_accounRoleMapper.Map).ToList();
            return Ok(data);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var accountrole = _accountRoleRepository.GetByGuid(guid);
            if (accountrole is null)
            {
                return NotFound();
            }

            var data = _accounRoleMapper.Map(accountrole);

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(AccountRoleVM accountRoleVM)
        {
            var accountRoleConverted = _accounRoleMapper.Map(accountRoleVM);

            var result = _accountRoleRepository.Create(accountRoleConverted);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(AccountRoleVM accountRoleVM)
        {
            var accountRoleConverted = _accounRoleMapper.Map(accountRoleVM);
            var isUpdated = _accountRoleRepository.Update(accountRoleConverted);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _accountRoleRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
