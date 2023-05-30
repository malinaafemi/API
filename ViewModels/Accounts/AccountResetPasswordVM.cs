using API.Utility;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.Accounts
{
    public class AccountResetPasswordVM
    {
        public int OTP { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
