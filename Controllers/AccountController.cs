using API.Contracts;
using API.Model;
using API.Repositories;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Others;
using API.ViewModels.Educations;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController<Account, AccountVM>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper<Account, AccountVM> _accountMapper;
        private readonly IEmailService _emailService;
        public AccountController(IAccountRepository accountRepository, IMapper<Account, AccountVM> accountMapper, IEmployeeRepository employeeRepository, IEmailService emailService) : base(accountRepository, accountMapper)
        {
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
            _employeeRepository = employeeRepository;
            _emailService = emailService;
        }

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var accounts = _accountRepository.GetAll();
            if (!accounts.Any())
            {
                return NotFound(new ResponseVM<List<AccountVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = accounts.Select(_accountMapper.Map).ToList();

            return Ok(new ResponseVM<List<AccountVM>>
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
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return NotFound(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = _accountMapper.Map(account);

            return Ok(new ResponseVM<AccountVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }*/

        [HttpPost("Register")]

        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.Register(registerVM);
            switch (result)
            {
                case 0:
                    //return BadRequest("Registration failed");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Registration failed"
                    });

                case 1:
                    //return BadRequest("Email already exists");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Email already exists"
                    });
                case 2:
                    //return BadRequest("Phone number already exists");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Phone number already exists"
                    });
                case 3:
                    return Ok(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status200OK,
                        Status = HttpStatusCode.OK.ToString(),
                        Message = "Registration success"
                    });
            }

            return Ok(new ResponseVM<AccountVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Registration success"
            });

        }

        [HttpPost("Login")]

        public IActionResult Login(LoginVM loginVM)
        {
            var account = _accountRepository.Login(loginVM);

            if (account == null)
            {
                return NotFound(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Account not found"
                });
            }

            //if (account.Password != loginVM.Password)
            if (!Hashing.ValidatePassword(loginVM.Password, account.Password))
            {
                //return BadRequest("Password is invalid");
                return BadRequest(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is invalid"
                });
            }

            return Ok(new ResponseVM<AccountVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login success"
            });

        }

        /*[HttpPost]
        public IActionResult Create(AccountVM accountVM)
        {
            var accountConverted = _accountMapper.Map(accountVM);
            var result = _accountRepository.Create(accountConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _accountMapper.Map(result);
            return Ok(new ResponseVM<AccountVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }*/

        /*[HttpPut]
        public IActionResult Update(AccountVM accountVM)
        {
            var accountConverted = _accountMapper.Map(accountVM);
            var isUpdated = _accountRepository.Update(accountConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _accountMapper.Map(accountConverted);
            return Ok(new ResponseVM<AccountVM>
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
            var isDeleted = _accountRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<AccountVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }*/

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            // Cek apakah email dan OTP valid
            var account = _employeeRepository.FindGuidByEmail(changePasswordVM.Email);
            var changePass = _accountRepository.ChangePasswordAccount(account, changePasswordVM);
            switch (changePass)
            {
                case 0:
                    return BadRequest("");
                case 1:
                    //return Ok("Password has been changed successfully");
                    return Ok(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status200OK,
                        Status = HttpStatusCode.OK.ToString(),
                        Message = "Password has been changed succesfully"
                    });
                case 2:
                    //return BadRequest("Invalid OTP");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Invalid OTP"
                    });
                case 3:
                    //return BadRequest("OTP has already been used");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "OTP has already been used"
                    });
                case 4:
                    //return BadRequest("OTP expired");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "OTP expired"
                    });
                case 5:
                    //return BadRequest("Wrong Password No Same");
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Password not match"
                    });
                default:
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Error"
                    });
            }

            //return null
        }

        [HttpPost("ForgotPassword" + "{email}")]
        public IActionResult UpdateResetPass(String email)
        {

            var getGuid = _employeeRepository.FindGuidByEmail(email);
            if (getGuid == null)
            {
                //return NotFound("Account not found");
                return NotFound(new ResponseVM<AccountVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Account not found"
                });
            }

            var isUpdated = _accountRepository.UpdateOTP(getGuid);

            switch (isUpdated)
            {
                case 0:
                    //return BadRequest();
                    return BadRequest(new ResponseVM<AccountVM>
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Status = HttpStatusCode.BadRequest.ToString(),
                        Message = "Error"
                    });
                default:
                    var hasil = new AccountResetPasswordVM
                    {
                        Email = email,
                        OTP = isUpdated
                    };

                    _emailService.SetEmail(hasil.Email)
                                 .SetSubject("Forgot Password")
                                 .SetHtmlMessage($"Your OTP is {isUpdated}")
                                 .SendEmailAsync();
                        
                    return Ok(new ResponseVM<AccountResetPasswordVM>
                    {
                        Code = StatusCodes.Status200OK,
                        Status = HttpStatusCode.OK.ToString(),
                        Message = "OTP has been sent to your email",
                        Data = hasil
                    });

            }
        }

    }
}
