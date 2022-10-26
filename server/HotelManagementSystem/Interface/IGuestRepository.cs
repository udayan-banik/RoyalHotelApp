using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Interface
{
    public interface IGuestRepository
    {
        #region GetGuests
        Task<IEnumerable<Guest>> GetGuest();
        #endregion

        #region AddGuest
        Task<Guest> AddGuest(AddUpdateGuestWithoutId addGuestWithoutId);
        #endregion

        #region UpdateGuest
        Task<Guest> UpdateGuest(int Guestid, AddUpdateGuestWithoutId updateGuestWithoutId);
        #endregion
    }
}
