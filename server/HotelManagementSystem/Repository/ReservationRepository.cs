using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace HotelManagementSystem.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HMSApiDbcontext dbContext;
        public ReservationRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetReservations
        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await dbContext.Room_Reservations.ToListAsync();
        }
        #endregion

        #region AddReservation
        public async Task<Reservation> AddReservation(AddUpdateReservationWithoutId addReservationWithoutId,int CheckRoomId,int CheckGuestId)
        {
            var CheckRoom = dbContext.Rooms.Find(CheckRoomId);
            var CheckGuest = dbContext.Guests.Find(CheckGuestId);


            if (addReservationWithoutId != null && CheckGuest != null && CheckRoom != null && CheckRoom.Room_Status != false)
            {

                var room_Reservation = new Reservation();
                {
                    room_Reservation.Resevation_Check_In = DateTime.Parse(addReservationWithoutId.Resevation_Check_In);
                    room_Reservation.Resevation_Check_Out = DateTime.Parse(addReservationWithoutId.Resevation_Check_Out);
                    room_Reservation.Reservation_No_of_Guests = addReservationWithoutId.Reservation_No_of_Guests;
                    room_Reservation.Reservation_Status = true;
                    room_Reservation.Room_Id = CheckRoom.Room_Id;
                    room_Reservation.Guest_Id = CheckGuest.Guest_Id;
                }

                dbContext.Room_Reservations.Add(room_Reservation);

                CheckRoom.Room_Status = false;

                dbContext.SaveChangesAsync();

                #region Email to Guest
                var GuestEmail = CheckGuest.Guest_Email;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
                email.To.Add(MailboxAddress.Parse(GuestEmail));
                email.Subject = "Dear " + CheckGuest.Guest_Name + " your reservation is confirmed at Royal Hotel";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Your booking is confirmed with Reservation Id: " + room_Reservation.Reservation_Id + " and your check in date is: " + room_Reservation.Resevation_Check_In + " and your check out date is: " + room_Reservation.Resevation_Check_Out + " , Hope you enjoy your stay at Royal Hotel" };

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

        #region UpdateReservation
        public Task<Reservation> UpdateReservation(int Reservationid, AddUpdateReservationWithoutId updateReservationWithoutId, int CheckRoomId, int CheckGuestId)
        {
            var result = dbContext.Room_Reservations.Find(Reservationid);
            var CheckRoom = dbContext.Rooms.Find(CheckRoomId);
            var CheckGuest = dbContext.Guests.Find(CheckGuestId);

            if (result != null && CheckGuest != null && CheckRoom != null)
            {
                result.Resevation_Check_In = DateTime.Parse(updateReservationWithoutId.Resevation_Check_In);
                result.Resevation_Check_Out = DateTime.Parse(updateReservationWithoutId.Resevation_Check_Out);
                result.Reservation_No_of_Guests = updateReservationWithoutId.Reservation_No_of_Guests;
                result.Reservation_Status = updateReservationWithoutId.Reservation_Status;

 
                    result.Guest_Id= CheckGuest.Guest_Id;


                    result.Room_Id = CheckRoom.Room_Id;

                dbContext.SaveChanges();
            }
            return null;
        }
        #endregion

        #region DeleteReservation
        public async void DeleteReservation( int Reservationid)
        {
            var CheckReservation = dbContext.Room_Reservations.Find(Reservationid);

            if (CheckReservation != null)
            {
                dbContext.Room_Reservations.Remove(CheckReservation);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region CancelReservation
        public Task<Reservation> CancelReservation(int CheckReservationId)
        {
            
            var CheckReservation = dbContext.Room_Reservations.Find(CheckReservationId);

            if (CheckReservation != null)
            {

                var CheckGuest = CheckReservation.Guest_Id;

                var CheckRoom = CheckReservation.Room_Id;

                CheckReservation.Reservation_Status = false;

                var room = dbContext.Rooms.Find(CheckRoom);
                var guest = dbContext.Guests.Find(CheckGuest);

                room.Room_Status = true;

                dbContext.SaveChanges();

                #region Email to Guest
                var GuestEmail = guest.Guest_Email;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
                email.To.Add(MailboxAddress.Parse(GuestEmail));
                email.Subject = "Dear " + guest.Guest_Name + " your request for cancellation of your reservation has been processed";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Your booking is cancelled for Reservation Id:" + CheckReservation.Reservation_Id + " on date: " + DateTime.Today };

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

    }
}
