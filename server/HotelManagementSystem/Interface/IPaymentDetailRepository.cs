using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Interface
{
    public interface IPaymentDetailRepository
    {
        #region GetPaymentDetails
        Task<IEnumerable<PaymentDetail>> GetPaymentDetails();
        #endregion

        #region AddPaymentDetails
        Task<PaymentDetail> AddPaymentDetails(AddUpdatePaymentDetailsWithoutId addPaymentDetailsWithoutId, int CheckBillId);
        #endregion

        #region UpdatePaymentDetails
        Task<PaymentDetail> UpdatePaymentDetails(int PaymentId, AddUpdatePaymentDetailsWithoutId updatePaymentDetailsWithoutId, int CheckBillId);
        #endregion
    }
}
