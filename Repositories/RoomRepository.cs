using API.Contexts;
using API.Contracts;
using API.Model;

namespace API.Repositories
{
    public class RoomRepository : GeneralRepository<Room>, IRoomRepository
    {
        public RoomRepository(BookingManagementDbContext context) : base(context) { }

    }
}
