using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Repository;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "manager")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        #region GetReceptionist
        [HttpGet]
        [Route("/GetReceptionist")]
        public async Task<ActionResult> GetReceptionist()
        {
            try
            {
                return Ok(await _employeeRepository.GetReceptionist());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        #endregion

        #region AddReceptionist
        [HttpPost]
        [Route("/AddReceptionist")]
        public async Task<ActionResult> AddReceptionist(AddUpdateEmployeeWithoutId addEmployeeWithoutId)
        {
            try 
            {
                await _employeeRepository.AddReceptionist(addEmployeeWithoutId);
                return Ok("{\"msg\":\"New Employee Added\"}");
            }

            catch (Exception) 
            {
                return NotFound();
            }
        }
        #endregion

        #region UpdateReceptionist

        [HttpPut]
        [Route("/UpdateReceptionist")]
        public async Task<ActionResult> UpdateReceptionist(int Employeeid,AddUpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            try
            {
                await _employeeRepository.UpdateReceptionist(Employeeid,updateEmployeeWithoutId);
                return Ok("{\"msg\":\"Receptionist Update Successfull\"}");
            }

            catch (Exception) 
            { 
                return Ok("{\"msg\":\"You are not allowed\"}");
            }
            //catch (Exception)
            //{
            //    return Ok("{\"msg\":\"No such employee found\"}");
            //} 
        }

        #endregion

        #region DeleteReceptionist
        [HttpDelete]
        [Route("/DeleteReceptionist")]
        public IActionResult DeleteEmployee(int Employeeid)
        {
            try
            {
                    return Ok("{\"msg\":\"Employee Deleted\"}");
            }

            catch(Exception)
            {
                return NotFound("{\"msg\":\"You are not allowed\"}");

            }

            return NotFound("{\"msg\":\"No such employee found\"}");
        }
        #endregion
    }
}
