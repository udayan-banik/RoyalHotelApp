using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "receptionist")]

    public class BillController: ControllerBase
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            this._billRepository = billRepository;
        }

        #region GetBill
        [HttpGet]
        [Route("/GetBill")]
        public async Task<ActionResult> GetBill()
        {
            try
            {
                return Ok(await _billRepository.GetBill());
            }

            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AddBill
        [HttpPost]
        [Route("/AddBill")]
        public async Task<ActionResult> AddBill(int CheckGuestId,int CheckReservationId)
        {
            try
            {
                return Ok(await _billRepository.AddBill(CheckGuestId, CheckReservationId));
            }
            catch(Exception) 
            {
                return BadRequest();
            }
        }
        #endregion

        #region UpdateBill
        [HttpPut]
        [Route("/UpdateBill")]
        public async Task<ActionResult> UpdateBill(int Billid, AddUpdateBillWithoutId updateBillWithoutId, int CheckGuestId, int CheckReservationId)
        {
            try 
            {
                return Ok(await _billRepository.UpdateBill( Billid, updateBillWithoutId, CheckGuestId, CheckReservationId));
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region DeleteBill
        [HttpDelete]
        [Route("/DeleteBill")]
        public IActionResult DeleteBill(int Billid)
        {
            try 
            {
                return Ok();
            }

            catch(Exception)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
