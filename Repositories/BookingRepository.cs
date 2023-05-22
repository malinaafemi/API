using API.Contexts;
using API.Contracts;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    public BookingRepository(BookingManagementDbContext context) : base(context) { }

}
