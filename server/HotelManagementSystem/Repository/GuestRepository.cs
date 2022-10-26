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
    public class GuestRepository : IGuestRepository
    {
        private readonly HMSApiDbcontext dbContext;
        public GuestRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetGuests
        public async Task<IEnumerable<Guest>> GetGuest()
        {
            return await dbContext.Guests.ToListAsync();
        }
        #endregion

        #region AddGuest
        public async Task<Guest> AddGuest(AddUpdateGuestWithoutId addGuestWithoutId)
        {
            if (addGuestWithoutId != null)
            {
                var Guest = new Guest()
                {
                    Guest_Aadhar_Id = addGuestWithoutId.Guest_Aadhar_Id,
                    Guest_Address = addGuestWithoutId.Guest_Address,
                    Guest_Age = addGuestWithoutId.Guest_Age,
                    Guest_Email = addGuestWithoutId.Guest_Email,
                    Guest_Name = addGuestWithoutId.Guest_Name,
                    Guest_Phone_Number = addGuestWithoutId.Guest_Phone_Number,
                };
                await dbContext.Guests.AddAsync(Guest);
                await dbContext.SaveChangesAsync();
            }
            return null;
        }
        #endregion

        # region UpdateGuest
        public async Task<Guest> UpdateGuest( int Guestid, AddUpdateGuestWithoutId updateGuestWithoutId)
        {
            var CheckGuest = dbContext.Guests.Find(Guestid);

            if (CheckGuest != null)
            {
                CheckGuest.Guest_Name = updateGuestWithoutId.Guest_Name;
                CheckGuest.Guest_Phone_Number = updateGuestWithoutId.Guest_Phone_Number;
                CheckGuest.Guest_Age = updateGuestWithoutId.Guest_Age;
                CheckGuest.Guest_Email = updateGuestWithoutId.Guest_Email;
                CheckGuest.Guest_Address = updateGuestWithoutId.Guest_Address;
                CheckGuest.Guest_Aadhar_Id = updateGuestWithoutId.Guest_Aadhar_Id;

                await dbContext.SaveChangesAsync();
            }
            return null;
        }
        #endregion
    }
}
