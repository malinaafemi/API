namespace API.Model
{
    public class Education : BaseEntity
    {
        string Major { get; set; }
        string Degree { get; set; }
        float GPA { get; set; }
        Guid UniversityGuid { get; set; }

    }
}
