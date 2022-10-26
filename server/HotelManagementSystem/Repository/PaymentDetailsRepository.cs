using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Data;
using MailKit.Net.Smtp;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repository
{
    public class PaymentDetailsRepository : IPaymentDetailRepository
    {
        private readonly HMSApiDbcontext dbContext;
        public PaymentDetailsRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        #region GetPaymentDetails
        public async Task<IEnumerable<PaymentDetail>> GetPaymentDetails()
        {
            return await dbContext.Payment_Details.ToListAsync();
        }
        #endregion

        #region AddPaymentDetails
        public Task<PaymentDetail> AddPaymentDetails(AddUpdatePaymentDetailsWithoutId addPaymentDetailsWithoutId,int CheckBillId)
        {
            var CheckBill = dbContext.Bills.Find(CheckBillId);
            if (addPaymentDetailsWithoutId != null)
            {
                var Payment = new PaymentDetail();

                Payment.Payment_Card = addPaymentDetailsWithoutId.Payment_Card;
                Payment.Payment_Card_Holder_Name = addPaymentDetailsWithoutId.Payment_Card_Holder_Name;

                if (CheckBill != null)
                {
                    Payment.Bill_Id = CheckBill.Bill_Id;


                    dbContext.Payment_Details.Add(Payment);
                    dbContext.SaveChanges();

                    #region Email to Guest
                    var guest = dbContext.Guests.Find(CheckBill.Guest_Id);
                    var CheckReservation = dbContext.Room_Reservations.Find(CheckBill.Reservation_Id);

                    var GuestEmail = guest.Guest_Email;

                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(GuestEmail));
                    email.Subject = "Dear " + guest.Guest_Name + " your bill has been paid successfully!!";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Dear " + guest.Guest_Name + ", your bill details are: \n Bill id: " + CheckBill.Bill_Id + "\n Room id: " + CheckReservation.Room_Id + "\n Bill Amount:" + CheckBill.Bill_Amount + "\n Thank You for your vist. Please visit us again at Royal Hotel." };

                    using var smpt = new SmtpClient();
                    smpt.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smpt.Authenticate("royal.hotel.ind@gmail.com", "bazkvpswtwzrkrzm");
                    smpt.Send(email);
                    smpt.Disconnect(true);
                    #endregion
                }
            }
            return null;
        }
        #endregion

        #region UpdatePaymentDetails
        public Task<PaymentDetail> UpdatePaymentDetails(int PaymentId, AddUpdatePaymentDetailsWithoutId updatePaymentDetailsWithoutId, int CheckBillId)
        {
            var result = dbContext.Payment_Details.Find(PaymentId);
            var CheckBill = dbContext.Bills.Find(CheckBillId);

            if (result != null)
            {
                result.Payment_Card = updatePaymentDetailsWithoutId.Payment_Card;
                result.Payment_Card_Holder_Name = updatePaymentDetailsWithoutId.Payment_Card_Holder_Name;
                
                if (CheckBill != null)
                    result.Bill_Id = CheckBill.Bill_Id;

                dbContext.SaveChangesAsync();

            }
            return null;
        }
        #endregion
    }
}
