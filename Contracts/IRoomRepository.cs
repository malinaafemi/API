﻿using API.Model;
using API.ViewModels.Rooms;

namespace API.Contracts
{
    public interface IRoomRepository : IGeneralRepository<Room>
    {
        IEnumerable<MasterRoomVM> GetByDate(DateTime dateTime);

        IEnumerable<RoomUsedVM> GetCurrentlyUsedRooms();

        IEnumerable<RoomAvailableVM> GetAvailableRoom();
    }
}
