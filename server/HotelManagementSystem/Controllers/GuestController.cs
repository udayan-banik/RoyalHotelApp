using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "receptionist,owner")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository ;
        public GuestController(IGuestRepository guestRepository)
        {
            this._guestRepository = guestRepository;
        }

        #region GetGuests
        [HttpGet]
        [Route("/GetGuests")]
        public async Task<ActionResult> GetGuest()
        {
            try
            {
                return Ok(await _guestRepository.GetGuest()); 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AddGuest
        [HttpPost]
        [Route("/AddGuest")]
        public async Task<ActionResult> AddGuest(AddUpdateGuestWithoutId addGuestWithoutId)
        {
            try
            {
                await _guestRepository.AddGuest(addGuestWithoutId);
                return Ok("New Guest Added");
            }

            catch(Exception) 
            {
                return BadRequest();
            }
        }
        #endregion

        # region UpdateGuest
        [HttpPut]
        [Route("/UpdateGuest")]
        public async Task<ActionResult> UpdateGuest(int Guestid, AddUpdateGuestWithoutId updateGuestWithoutId)
        {
            try
            {
                await _guestRepository.AddGuest(updateGuestWithoutId);
                return Ok("Guest with Guest id:" + Guestid  + " Updated");
            }
            catch (Exception) 
            {
                return NotFound("No Guest Found");
            } 
        }
        #endregion
    }
}
