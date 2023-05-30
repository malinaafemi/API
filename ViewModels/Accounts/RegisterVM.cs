using API.Model;
using API.Utility;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.Accounts
{
    public class RegisterVM
    {
        //public string NIK { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public GenderLevel Gender { get; set; }

        public DateTime HiringDate { get; set; }

        [EmailAddress]
        [NikEmailPhoneValidation(nameof(Email))]
        public string Email { get; set; }

        [Phone]
        [NikEmailPhoneValidation(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        public string Major { get; set; }

        public string Degree { get; set; }

        [Range(0, 4, ErrorMessage = "GPA must be in range 0-4")]
        public float GPA { get; set; }

        //public Guid UniversityGuid { get; set; }

        public string UniversityCode { get; set; }

        public string UniversityName { get; set; }

        [PasswordValidation]
        public string Password { get; set; }
        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        // public University? University { get; set; }


    }
}
