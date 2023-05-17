namespace API.Model
{
    public class Room : BaseEntity
    {
        string Name { get; set; }
        int Floor { get; set; }
        int Capacity { get; set; }

    }
}
