using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HotelManagementSystem.Repository
{

    public class BillRepository : IBillRepository
    {
        private readonly HMSApiDbcontext dbContext;
        public BillRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetBill
        public async Task<IEnumerable<Bill>> GetBill()
        {
            return await dbContext.Bills.ToListAsync();
        }
        #endregion

        #region AddBill
        public async Task<Bill> AddBill(int CheckGuestId,int CheckReservationId)
        {
            var CheckGuest = dbContext.Guests.Find(CheckGuestId);
            var CheckReservation = dbContext.Room_Reservations.Find(CheckReservationId);

            if (CheckGuest != null && CheckReservation != null) {
               
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

            await dbContext.Bills.AddAsync(Bill);
            await dbContext.SaveChangesAsync();

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
            }

            return null;
        }
        #endregion

        #region UpdateBill
        [HttpPut]
        [Route("/UpdateBill")]
        public async Task<Bill> UpdateBill(int Billid, AddUpdateBillWithoutId updateBillWithoutId, int CheckGuestId, int CheckReservationId)
        {
            var result = dbContext.Bills.Find(Billid);

            var CheckGuest = dbContext.Guests.Find(CheckGuestId);
            var CheckReservation = dbContext.Room_Reservations.Find(CheckReservationId);

            if (result != null && CheckGuest != null && CheckReservation != null)
            {
                    
                result.Reservation_Id = CheckReservation.Reservation_Id;
                result.Guest_Id = CheckGuest.Guest_Id;
                
                result.Bill_Amount = updateBillWithoutId.Bill_Amount;
                result.Bill_Date = DateTime.Today;

                await dbContext.SaveChangesAsync();

            }
            
            return null;
        }
        #endregion

        #region DeleteBill
        [HttpDelete]
        [Route("/DeleteBill")]
        public async void DeleteBill(int Billid)
        {
            var result = dbContext.Bills.Find(Billid);

            if (result != null)
            {
                dbContext.Bills.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
