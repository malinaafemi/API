namespace API.Model
{
    public class AccountRole : BaseEntity
    {

        Guid AccountGuid { get; set; }
        Guid RoleGuid { get; set; }

    }
}
