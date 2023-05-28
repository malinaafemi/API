using API.Contexts;
using API.Model;
using API.ViewModels.Bookings;

namespace API.Contracts
{
    public interface IBookingRepository : IGeneralRepository<Booking>
    {
        IEnumerable<BookingDurationVM> GetBookingDuration();
        BookingDetailVM GetBookingDetailByGuid(Guid guid);
        IEnumerable<BookingDetailVM> GetAllBookingDetail();

    }
}
