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

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomRepository.GetAll();
            if (!rooms.Any())
            {
                return NotFound(new ResponseVM<List<RoomVM>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }

            var data = rooms.Select(_roomMapper.Map).ToList();

            return Ok(new ResponseVM<List<RoomVM>>
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
            var room = _roomRepository.GetByGuid(guid);
            if (room is null)
            {
                return NotFound(new ResponseVM<RoomVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Data not found"
                });
            }
            var data = _roomMapper.Map(room);

            return Ok(new ResponseVM<RoomVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Get data succeed",
                Data = data
            });
        }

        [HttpPost]
        public IActionResult Create(RoomVM roomVM)
        {
            var roomConverted = _roomMapper.Map(roomVM);

            var result = _roomRepository.Create(roomConverted);
            if (result is null)
            {
                return BadRequest(new ResponseVM<RoomVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Create failed"
                });
            }

            var resultConverted = _roomMapper.Map(result);
            return Ok(new ResponseVM<RoomVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Create success",
                Data = resultConverted
            });
        }

        [HttpPut]
        public IActionResult Update(RoomVM roomVM)
        {
            var roomConverted = _roomMapper.Map(roomVM);
            var isUpdated = _roomRepository.Update(roomConverted);
            if (!isUpdated)
            {
                return BadRequest(new ResponseVM<RoomVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Update failed"
                });
            }

            var data = _roomMapper.Map(roomConverted);
            return Ok(new ResponseVM<RoomVM>
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
            var isDeleted = _roomRepository.Delete(guid);
            if (!isDeleted)
            {
                return BadRequest(new ResponseVM<RoomVM>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Delete failed"
                });
            }

            return Ok(new ResponseVM<RoomVM>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete success"
            });
        }*/

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
