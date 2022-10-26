using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using MimeKit;
using MailKit.Net.Smtp;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "receptionist")]

    public class BillController : Controller
    {
        private readonly HMSApiDbcontext dbContext;

        public BillController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetBill
        [HttpGet]
        [Route("/GetBill")]
        public IEnumerable<Bill> GetBill()
        {
            return dbContext.Bills;
        }
        #endregion

        #region AddBill
        [HttpPost]
        [Route("/AddBill")]
        public IActionResult AddBill(int CheckGuestId,int CheckReservationId)
        {
            var CheckGuest = dbContext.Guests.Find(CheckGuestId);
            var CheckReservation = dbContext.Room_Reservations.Find(CheckReservationId);

            if (CheckGuest == null)
                return NotFound("This Guest Id is not present");

            if (CheckReservation == null)
                return NotFound("This reservation Id is not present");

            float CalculateAmount()
            {
                var CheckIn  = CheckReservation.Resevation_Check_In;
                var CheckOut = CheckReservation.Resevation_Check_Out;

                int No_of_days = (CheckOut - CheckIn).Days;


                int Roomid = CheckReservation.Room_Id;
                
                var room = dbContext.Rooms.Find(Roomid);

                float AmountPerDay = room.Room_Price ;

                return (AmountPerDay) * (No_of_days);
            }

            var Bill = new Bill();
            {

                Bill.Bill_Amount = CalculateAmount();

                Bill.Bill_Date = DateTime.Today;

                Bill.Guest_Id = CheckGuest.Guest_Id;

                Bill.Reservation_Id = CheckReservation.Reservation_Id;

            }

            dbContext.Bills.Add(Bill);
            dbContext.SaveChanges();

            #region Email to Guest
            var GuestEmail = CheckGuest.Guest_Email;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
            email.To.Add(MailboxAddress.Parse(GuestEmail));
            email.Subject = "Dear " + CheckGuest.Guest_Name + " your bill has been processsed";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Dear " + CheckGuest.Guest_Name + ", your bill details are: \n Bill id: " + Bill.Bill_Id + "\n Room id: " + CheckReservation.Room_Id + "\n Bill Amount:" + Bill.Bill_Amount };

            using var smpt = new SmtpClient();
            smpt.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smpt.Authenticate("royal.hotel.ind@gmail.com", "bazkvpswtwzrkrzm");
            smpt.Send(email);
            smpt.Disconnect(true);
            #endregion


            return Ok("{\"msg\":\"New Bill Added\"}");
        }
        #endregion

        #region UpdateBill
        [HttpPut]
        [Route("/UpdateBill")]
        public IActionResult UpdateBill(int Billid, AddUpdateBillWithoutId updateBillWithoutId, int CheckGuestId, int CheckReservationId)
        {
            var result = dbContext.Bills.Find(Billid);

            var CheckGuest = dbContext.Guests.Find(CheckGuestId);
            var CheckReservation = dbContext.Room_Reservations.Find(CheckReservationId);



            if (result != null)
            {
                
                if (CheckGuest == null)
                {
                    return NotFound("{\"msg\":\"This Guest Id is not present\"}");
                }
                else
                {
                    result.Guest_Id = CheckGuest.Guest_Id;
                }

                
                if (CheckReservation == null)
                {
                    return NotFound("{\"msg\":\"This reservation Id is not present\"}");
                }
                else
                {
                    result.Reservation_Id = CheckReservation.Reservation_Id;
                }
                result.Bill_Amount = updateBillWithoutId.Bill_Amount;
                result.Bill_Date = DateTime.Today; ;

                dbContext.SaveChanges();

                return Ok("{\"msg\":\"Update Successfull\"}");
            }
            else
            {
                return NotFound("{\"msg\":\"No bill id found\"}");
            }
        }
        #endregion

        #region DeleteBill
        [HttpDelete]
        [Route("/DeleteBill")]
        public IActionResult DeleteBill(int Billid)
        {
            var result = dbContext.Bills.Find(Billid);

            if (result != null)
            {
                dbContext.Bills.Remove(result);
                dbContext.SaveChanges();
                return Ok("{\"msg\":\"Bill Deleted\"}");
            }
            return NotFound("{\"msg\":\"No bill id found\"}");
        }
        #endregion
    }
}
