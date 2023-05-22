using API.Contexts;
using API.Contracts;
using API.Model;

namespace API.Repositories
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        public RoleRepository(BookingManagementDbContext context) : base(context) { }

    }
}
