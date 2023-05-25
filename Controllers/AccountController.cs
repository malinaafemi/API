using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper<Account, AccountVM> _accountMapper;
        public AccountController(IAccountRepository accountRepository, IMapper<Account, AccountVM> accountMapper)
        {
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = _accountRepository.GetAll();
            if (!accounts.Any())
            {
                return NotFound();
            }

            var data = accounts.Select(_accountMapper.Map).ToList();

            return Ok(data);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return NotFound();
            }

            var data = _accountMapper.Map(account);

            return Ok(data);
        }

        [HttpPost("Register")]

        public IActionResult Register(RegisterVM registerVM)
        {
            
            var result = _accountRepository.Register(registerVM);
            switch (result)
            {
                case 0:
                    return BadRequest("Registration failed");
                case 1:
                    return BadRequest("Email already exists");
                case 2:
                    return BadRequest("Phone number already exists");
                case 3:
                    return Ok("Registration success");
            }

            return Ok();

        }

        [HttpPost]
        public IActionResult Create(AccountVM accountVM)
        {
            var accountConverted = _accountMapper.Map(accountVM);
            var result = _accountRepository.Create(accountConverted);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(AccountVM accountVM)
        {
            var accountConverted = _accountMapper.Map(accountVM);
            var isUpdated = _accountRepository.Update(accountConverted);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _accountRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
