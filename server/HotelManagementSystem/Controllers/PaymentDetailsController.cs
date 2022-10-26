using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Data;
using MailKit.Net.Smtp;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Repository;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "receptionist")]
    public class PaymentDetailsController: ControllerBase
    {
        private readonly IPaymentDetailRepository _paymentdetailRepository;

        public PaymentDetailsController(IPaymentDetailRepository paymentdetailRepository)
        {
            this._paymentdetailRepository = paymentdetailRepository;
        }

        #region GetPaymentDetails
        [HttpGet]
        [Route("/GetPaymentDetails")]
        public async Task<ActionResult> GetPaymentDetails()
        {
            try
            {
                return Ok(await _paymentdetailRepository.GetPaymentDetails());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AddPaymentDetails
        [HttpPost]
        [Route("/AddPaymentDetails")]
        public async Task<ActionResult> AddPaymentDetails(AddUpdatePaymentDetailsWithoutId addPaymentDetailsWithoutId,int CheckBillId)
        {
            try
            {
                await _paymentdetailRepository.AddPaymentDetails(addPaymentDetailsWithoutId, CheckBillId);
                return Ok("{\"msg\":\"New Payment Details Added\"}");

            }

            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region UpdatePaymentDetails
        [HttpPut]
        [Route("/UpdatePaymentDetails")]
        public async Task<ActionResult> UpdatePaymentDetails(int PaymentId, AddUpdatePaymentDetailsWithoutId updatePaymentDetailsWithoutId, int CheckBillId)
        {
            try
            {
                await _paymentdetailRepository.UpdatePaymentDetails(PaymentId, updatePaymentDetailsWithoutId, CheckBillId);
                return Ok("Payment details successfully updated");
            }
            catch
            {
                //return NotFound("{\"msg\":\"This Payment Id is not present\"}");
                return BadRequest();
            }
        }
        #endregion
    }
}
