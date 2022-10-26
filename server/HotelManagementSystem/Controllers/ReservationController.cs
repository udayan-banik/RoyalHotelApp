using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }

        #region GetReservations
        [HttpGet]
        [Route("/GetReservations")]
        [Authorize(Roles = "owner,receptionist,manager")]
        public async Task<IActionResult> GetReservations()
        {
            try
            {
                return Ok(await _reservationRepository.GetReservations());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        #endregion

        #region AddReservation
        [HttpPost]
        [Route("/AddReservation")]
        [Authorize(Roles = "receptionist,manager")]
        public async Task<IActionResult> AddReservation(AddUpdateReservationWithoutId addReservationWithoutId,int CheckRoomId,int CheckGuestId)
        {
            try 
            {
                await _reservationRepository.AddReservation(addReservationWithoutId, CheckRoomId, CheckGuestId);
                return Ok("New Reservation Added");
            }
            catch
            {
                return BadRequest();
            }

            
        }
        #endregion

        #region UpdateReservation
        [HttpPut]
        [Route("/UpdateReservation")]
        [Authorize(Roles = "receptionist,manager")]
        public async Task<IActionResult> UpdateReservation(int Reservationid, AddUpdateReservationWithoutId updateReservationWithoutId, int CheckRoomId, int CheckGuestId)
        {
            try
            {
                await _reservationRepository.UpdateReservation(Reservationid, updateReservationWithoutId, CheckRoomId, CheckGuestId);
                return Ok("Update Successfully");

            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region DeleteReservation
        [HttpDelete]
        [Route("/DeleteReservation")]
        public async Task<ActionResult> DeleteReservation( int Reservationid)
        {
            try
            {
                _reservationRepository.DeleteReservation(Reservationid);
                return Ok("Reservation record deleted successfully");
            }
            catch
            {
                return NotFound("This reservation not found");
            }
        }
        #endregion

        #region CancelReservation
        [HttpPost]
        [Route("/CancelReservation")]
        [Authorize(Roles = "receptionist,manager")]
        public async Task<ActionResult> CancelReservation(int CheckReservationId)
        {
            try
            {
                await _reservationRepository.CancelReservation(CheckReservationId);
                return Ok("Reservation for reservation id:" + CheckReservationId + "Cancelled");
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
