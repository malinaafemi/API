namespace API.Model
{
    public class Account : BaseEntity
    {
        string Password { get; set; }
        bool IsDeleted { get; set; }
        int Otp { get; set; }
        bool IsUsed { get; set; }
        DateTime ExpiredTime { get; set; }

    }
}
