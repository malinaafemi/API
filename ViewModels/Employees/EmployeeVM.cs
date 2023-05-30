using API.Utility;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels.Employees
{
    public class EmployeeVM
    {
        public Guid? Guid { get; set; }

        [NikEmailPhoneValidation(nameof(NIK))]
        public string NIK { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public GenderLevel Gender { get; set; }

        public DateTime HiringDate { get; set; }

        [EmailAddress]
        [NikEmailPhoneValidation(nameof(Email))]
        public string Email { get; set; }

        [Phone]
        [NikEmailPhoneValidation(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }
    }
}
