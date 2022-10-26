using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using MailKit.Net.Smtp;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Repository;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController: ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }

        #region AllDepartments
        [HttpGet]
        [Route("/Departments")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult> GetEmployee()
        {
            try
            {
                return Ok(await _ownerRepository.GetEmployee());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AddEmployee
        [HttpPost]
        [Route("/AddEmployee")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult> AddEmployee(AddUpdateEmployeeWithoutId addEmployeeWithoutId)
        {
            await _ownerRepository.AddEmployee(addEmployeeWithoutId);
            return Ok("New Employee Added");
        }
        #endregion

        #region UpdateEmployee
        [HttpPut]
        [Route("/UpdateEmployee")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult> UpdateEmployee(int Employeeid, AddUpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            try 
            { 
                await _ownerRepository.UpdateEmployee(Employeeid, updateEmployeeWithoutId);
                return Ok("Employee Updated");
            }
            catch (Exception) 
            {
                return NotFound("Employee not found");

            }
        }
        #endregion

        #region DeleteEmployee
        [HttpDelete]
        [Route("/DeleteEmployee")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult> DeleteEmployee(int Employeeid)
        {
            try
            {
                _ownerRepository.DeleteEmployee(Employeeid);
                return Ok("Employee Deleted");
            }

            catch
            {
                return NotFound("Employee not found");
            }
        }
        #endregion

        #region AllRooms
        [HttpGet]
        [Route("/AllRooms")]
        public async Task<ActionResult> GetRoom()
        {
            try
            {
                return Ok(await _ownerRepository.GetRoom());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion

        #region AllGuests
        [HttpGet]
        [Route("/AllGuests")]
        public async Task<ActionResult> GetGuest()
        {
            try
            {
                return Ok(await _ownerRepository.GetGuest());
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        #endregion
    }
}
