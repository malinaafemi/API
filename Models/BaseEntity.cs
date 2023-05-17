namespace API.Model
{
    // biar gabisa di instance dan cuma property aja
    public abstract class BaseEntity
    {
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}
    }
}
