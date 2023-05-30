using API.Contracts;
using API.Model;
using API.Repositories;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Bookings;
using API.ViewModels.Educations;
using API.ViewModels.Others;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseController<Booking, BookingVM>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper<Booking, BookingVM> _bookingMapper;
        public BookingController(IBookingRepository bookingRepository, IMapper<Booking, BookingVM> bookingMapper) : base(bookingRepository, bookingMapper)
        {
            _bookingRepository = bookingRepository;
            _bookingMapper = bookingMapper;
        }

        [HttpGet("BookingDuration")]
        public IActionResult GetDuration()
        {
            var bookingLengths = _bookingRepository.GetBookingDuration();
            if (!bookingLengths.Any())
            {
                return NotFound(new ResponseVM<IEnumerable<BookingDurationVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            //return Ok(bookingLengths);
            return Ok(new ResponseVM<IEnumerable<BookingDurationVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = bookingLengths
            });
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("BookingDetail")]
        public IActionResult GetAllBookingDetail()
        {
            try
            {

                var results = _bookingRepository.GetAllBookingDetail();

                return Ok(new ResponseVM<List<BookingDetailVM>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Get all booking detail succeed",
                    Data = results.ToList()
                });
            }
            catch
            {
                return NotFound(new ResponseVM<BookingDetailVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

        }

        [HttpGet("BookingDetail/{guid}")]
        public IActionResult GetDetailByGuid(Guid guid)
        {
            try
            {
                var data = _bookingRepository.GetBookingDetailByGuid(guid);

                if (data is null)
                {
                    return NotFound(new ResponseVM<BookingDetailVM>
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data not found"
                    });
                }

                return Ok(new ResponseVM<BookingDetailVM>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Get data succeed",
                    Data = data
                });
            }
            catch
            {
                return NotFound(new ResponseVM<BookingDetailVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }
        }

    }
}
