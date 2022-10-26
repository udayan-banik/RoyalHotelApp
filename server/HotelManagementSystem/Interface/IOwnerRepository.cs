using HotelManagementSystem.Dtos;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HotelManagementSystem.Interface
{
    public interface IOwnerRepository
    {
        #region AllDepartments
        Task<IEnumerable<Employee>> GetEmployee();
        #endregion

        #region AddEmployee
        Task<Employee> AddEmployee(AddUpdateEmployeeWithoutId addEmployeeWithoutId);
        #endregion

        #region UpdateEmployee
        Task<Employee> UpdateEmployee(int Employeeid, AddUpdateEmployeeWithoutId updateEmployeeWithoutId);
        #endregion

        #region DeleteEmployee
        void DeleteEmployee(int Employeeid);
        #endregion

        #region AllRooms
        Task<IEnumerable<Room>> GetRoom();
        #endregion

        #region AllGuests
        Task<IEnumerable<Guest>> GetGuest();
        #endregion
    }
}
