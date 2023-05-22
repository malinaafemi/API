using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.Bookings;
using API.ViewModels.Educations;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper<Booking, BookingVM> _bookingMapper;
        public BookingController(IBookingRepository bookingRepository, IMapper<Booking, BookingVM> bookingMapper)
        {
            _bookingRepository = bookingRepository;
            _bookingMapper = bookingMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _bookingRepository.GetAll();
            if (!bookings.Any())
            {
                return NotFound();
            }
            var data = bookings.Select(_bookingMapper.Map).ToList();

            return Ok(data);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var booking = _bookingRepository.GetByGuid(guid);
            if (booking is null)
            {
                return NotFound();
            }

            var data = _bookingMapper.Map(booking);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(BookingVM bookingVM)
        {
            var bookingConverted = _bookingMapper.Map(bookingVM);

            var result = _bookingRepository.Create(bookingConverted);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(BookingVM bookingVM)
        {
            var bookingConverted = _bookingMapper.Map(bookingVM);
            var isUpdated = _bookingRepository.Update(bookingConverted);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var isDeleted = _bookingRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
