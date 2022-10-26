using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        #region GetRooms
        [HttpGet]
        [Route("/GetRooms")]
        [Authorize(Roles = "owner,manager,receptionist")]
        public async Task<ActionResult> GetRoom()
        {
            try
            {
                return Ok(await _roomRepository.GetRoom());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region BookedRooms
        [HttpGet]
        [Route("/BookedRooms")]
        [Authorize(Roles = "owner,manager,receptionist")]
        public async Task<ActionResult> GetBookedRoom()
        {
            try
            {
                return Ok(await _roomRepository.GetBookedRoom());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region UnbookedRooms
        [HttpGet]
        [Route("/UnbookedRooms")]
        [Authorize(Roles = "owner,manager,receptionist")]
        public async Task<ActionResult> GetUnBookedRoom()
        {
            try
            {
                return Ok(await _roomRepository.GetUnBookedRoom());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AddRoom
        [HttpPost]
        [Route("/AddRoom")]
        [Authorize(Roles = "owner,manager")]
        public async Task<ActionResult> AddRoom(AddUpdateRoomWithoutId addRoomWithoutId)
        {
            try
            {
                await _roomRepository.AddRoom(addRoomWithoutId);
                return Ok("New room Added");
            }
            catch(Exception) 
            {
                return BadRequest();
            }
        }
        #endregion

        #region UpdateRoom
        [HttpPut]
        [Route("/UpdateRoom")]
        [Authorize(Roles = "owner,manager")]
        public async Task<ActionResult> UpdateRoom(int Roomid,AddUpdateRoomWithoutId updateRoomWithoutId)
        {
            try 
            {
                await _roomRepository.UpdateRoom(Roomid,updateRoomWithoutId);
                return Ok("Room:"+Roomid+" Details" +" Updated");
            }

            catch (Exception)
            {
                return NotFound();
            }
        }
        #endregion

        #region DeleteRoom
        [HttpDelete]
        [Route("/DeleteRoom")]
        [Authorize(Roles ="owner,manager")]
        public IActionResult DeleteRoom(int RoomId)
        {
            try 
            {
                return Ok("Room:" + RoomId + " Deleted");
            }

            catch(Exception)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
