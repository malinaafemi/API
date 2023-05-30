using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.Accounts
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
