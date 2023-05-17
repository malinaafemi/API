namespace API.Model
{
    public class Booking : BaseEntity
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int Status { get; set; }
        string Remarks { get; set; }
        Guid RoomGuid { get; set; }
        Guid EmployeeGuid { get; set; }
    }
}
