using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Interface
{
    public interface IRoomRepository
    {
        #region GetRooms
        Task<IEnumerable<Room>> GetRoom();
        #endregion

        #region BookedRooms
        Task<IEnumerable<Room>> GetBookedRoom();
        #endregion

        #region UnbookedRooms
        Task<IEnumerable<Room>> GetUnBookedRoom();
        #endregion

        #region AddRoom
        Task<Room> AddRoom(AddUpdateRoomWithoutId addRoomWithoutId);
        #endregion

        #region UpdateRoom
        Task<Room> UpdateRoom(int Roomid, AddUpdateRoomWithoutId updateRoomWithoutId);
        #endregion

        #region DeleteRoom
        void DeleteRoom(int RoomId);
        #endregion
    }
}
