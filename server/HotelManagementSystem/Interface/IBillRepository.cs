using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Interface
{
    public interface IBillRepository
    {
        #region GetBill
        Task<IEnumerable<Bill>> GetBill();
        #endregion

        #region AddBill
        Task<Bill> AddBill(int CheckGuestId,int CheckReservationId);
        #endregion

        #region UpdateBill
        Task<Bill> UpdateBill(int Billid, AddUpdateBillWithoutId updateBillWithoutId, int CheckGuestId, int CheckReservationId);
        #endregion

        #region DeleteBill
        void DeleteBill(int Billid);
        #endregion
    }
}
