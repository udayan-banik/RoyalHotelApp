using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Interface
{
    public interface IReservationRepository
    {
        #region GetReservations
        Task<IEnumerable<Reservation>> GetReservations();
        #endregion

        #region AddReservation
        Task<Reservation> AddReservation(AddUpdateReservationWithoutId addReservationWithoutId, int CheckRoomId, int CheckGuestId);
        #endregion

        #region UpdateReservation
        Task<Reservation> UpdateReservation(int Reservationid, AddUpdateReservationWithoutId updateReservationWithoutId, int CheckRoomId, int CheckGuestId);
        #endregion

        #region DeleteReservation
        void DeleteReservation(int Reservationid);
        #endregion

        #region CancelReservation
        Task<Reservation> CancelReservation(int CheckReservationId);
        #endregion
    }
}
