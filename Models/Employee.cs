namespace API.Model
{
    public class Employee : BaseEntity
    {
        string NIK { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        int Gender { get; set; }
        DateTime HiringDate { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }

    }
}
