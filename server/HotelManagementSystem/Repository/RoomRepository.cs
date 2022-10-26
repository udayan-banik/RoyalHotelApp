using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HotelManagementSystem.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HMSApiDbcontext dbContext;
        public RoomRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetRooms
        public async Task<IEnumerable<Room>> GetRoom()
        {
            return await dbContext.Rooms.ToListAsync();
        }
        #endregion

        #region BookedRooms
        public async Task<IEnumerable<Room>> GetBookedRoom()
        {
            return await dbContext.Rooms.Where(x => x.Room_Status == false).ToListAsync();
        }
        #endregion

        #region UnbookedRooms
        public async Task<IEnumerable<Room>> GetUnBookedRoom()
        {
            return await dbContext.Rooms.Where(x => x.Room_Status == true).ToListAsync();
        }
        #endregion

        #region AddRoom
        public async Task<Room> AddRoom(AddUpdateRoomWithoutId addRoomWithoutId)
        {
            if (addRoomWithoutId != null)
            {
                var room = new Room()
                {
                    Room_Comment = addRoomWithoutId.Room_Comment,
                    Room_Inventory = addRoomWithoutId.Room_Inventory,
                    Room_Price = addRoomWithoutId.Room_Price,
                    Room_Status = addRoomWithoutId.Room_Status,
                };
                dbContext.Rooms.AddAsync(room);
                await dbContext.SaveChangesAsync();
                return room;
            }

            return null;
        }
        #endregion

        #region UpdateRoom
        public async Task<Room> UpdateRoom(int Roomid,AddUpdateRoomWithoutId updateRoomWithoutId)
        {
            var CheckRoom = await dbContext.Rooms.FirstOrDefaultAsync(e => e.Room_Id == Roomid);

            if(CheckRoom != null)
            {
                CheckRoom.Room_Price = updateRoomWithoutId.Room_Price;
                CheckRoom.Room_Comment = updateRoomWithoutId.Room_Comment;
                CheckRoom.Room_Status = updateRoomWithoutId.Room_Status;
                CheckRoom.Room_Inventory = updateRoomWithoutId.Room_Inventory;

                await dbContext.SaveChangesAsync();

                return CheckRoom;
            }

            return null;
        }
        #endregion

        #region DeleteRoom
        public async void DeleteRoom(int RoomId)
        {
            var CheckRoom = dbContext.Rooms.Find(RoomId);

            if (CheckRoom != null)
            {
                dbContext.Rooms.Remove(CheckRoom);
                await dbContext.SaveChangesAsync();

            }
        }
        #endregion
    }
}
