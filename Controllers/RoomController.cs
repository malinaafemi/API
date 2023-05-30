using API.Contracts;
using API.Model;
using API.Utility;
using API.ViewModels.AccountRoles;
using API.ViewModels.Accounts;
using API.ViewModels.Educations;
using API.ViewModels.Others;
using API.ViewModels.Rooms;
using API.ViewModels.Universities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : BaseController<Room, RoomVM>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper<Room, RoomVM> _roomMapper;
        public RoomController(IRoomRepository roomRepository, IMapper<Room, RoomVM> roomMapper) : base(roomRepository, roomMapper)
        {
            _roomRepository = roomRepository;
            _roomMapper = roomMapper;
        }

        [HttpGet("CurrentlyUsedRooms")]
        public IActionResult GetCurrentlyUsedRooms()
        {
            var room = _roomRepository.GetCurrentlyUsedRooms();
            if (room is null)
            {
                return NotFound(new ResponseVM<IEnumerable<RoomUsedVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseVM<IEnumerable<RoomUsedVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = room
            });
        }

        [HttpGet("CurrentlyUsedRoomsByDate")]
        public IActionResult GetCurrentlyUsedRooms(DateTime dateTime)
        {
            var room = _roomRepository.GetByDate(dateTime);
            if (room is null)
            {
                return NotFound(new ResponseVM<IEnumerable<MasterRoomVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseVM<IEnumerable<MasterRoomVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = room
            });
        }

        [HttpGet("AvailableRoom")]
        public IActionResult GetAvailableRoom()
        {
            try
            {
                var room = _roomRepository.GetAvailableRoom();
                if (room is null)
                {
                    return NotFound(new ResponseVM<IEnumerable<RoomAvailableVM>>
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.OK.ToString(),
                        Message = "Data not found"
                    });
                }

                return Ok(new ResponseVM<IEnumerable<RoomAvailableVM>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Get data succeed",
                    Data = room
                });
            }
            catch
            {
                return BadRequest(new ResponseVM<IEnumerable<RoomAvailableVM>>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Error"
                });
            }
        }

    }
}
