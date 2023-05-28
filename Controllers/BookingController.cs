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

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _bookingRepository.GetAll();
            if (!bookings.Any())
            {
                return NotFound(new ResponseVM<List<BookingVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }
            var data = bookings.Select(_bookingMapper.Map).ToList();

            return Ok(new ResponseVM<List<BookingVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var booking = _bookingRepository.GetByGuid(guid);
            if (booking is null)
            {
                return NotFound(new ResponseVM<BookingVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = _bookingMapper.Map(booking);
            return Ok(new ResponseVM<BookingVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(BookingVM bookingVM)
        {
            var bookingConverted = _bookingMapper.Map(bookingVM);

            var result = _bookingRepository.Create(bookingConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<BookingVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _bookingMapper.Map(result);
            return Ok(new ResponseVM<BookingVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }

        [HttpPut]
        public IActionResult Update(BookingVM bookingVM)
        {
            var bookingConverted = _bookingMapper.Map(bookingVM);
            var isUpdated = _bookingRepository.Update(bookingConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<BookingVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _bookingMapper.Map(bookingConverted);
            return Ok(new ResponseVM<BookingVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update success",
                Data = data
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _bookingRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<BookingVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<BookingVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }*/

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
