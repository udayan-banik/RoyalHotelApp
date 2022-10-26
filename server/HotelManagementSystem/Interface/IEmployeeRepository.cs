using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Interface
{
    public interface IEmployeeRepository
    {
        #region GetReceptionist
        Task<IEnumerable<Employee>> GetReceptionist();
        #endregion

        #region AddReceptionist
        Task<Employee> AddReceptionist(AddUpdateEmployeeWithoutId addEmployeeWithoutId);
        #endregion

        #region UpdateReceptionist
        Task<Employee> UpdateReceptionist(int Employeeid,AddUpdateEmployeeWithoutId updateEmployeeWithoutId);

        #endregion

        #region DeleteReceptionist
        void DeleteReceptionist(int Employeeid);
        #endregion 
    }
}
