using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using MailKit.Net.Smtp;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly HMSApiDbcontext dbContext;

        public OwnerController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        #region AllDepartments
        [HttpGet]
        [Route("/Departments")]
        [Authorize(Roles = "owner")]
        //[Authorize]
        public IActionResult GetEmployee()
        {
            return Ok(dbContext.Employees.ToList());
        }
        #endregion

        #region AddEmployee
        [HttpPost]
        [Route("/AddEmployee")]
        [Authorize(Roles = "owner")]

        //[Authorize]
        public IActionResult AddEmployee(AddUpdateEmployeeWithoutId addEmployeeWithoutId)
        {
            var Employee = new Employee()
            {
                Employee_Designation = addEmployeeWithoutId.Employee_Designation,
                Employee_Name = addEmployeeWithoutId.Employee_Name,
                Employee_Password = addEmployeeWithoutId.Employee_Password,
                Employee_Salary = addEmployeeWithoutId.Employee_Salary,
                Employee_Email = addEmployeeWithoutId.Employee_Email,
                Employee_Age = addEmployeeWithoutId.Employee_Age,
                Employee_PhoneNo = addEmployeeWithoutId.Employee_PhoneNo,
                Employee_Address = addEmployeeWithoutId.Employee_Address,
            };
            dbContext.Employees.Add(Employee);
            dbContext.SaveChanges();

            #region Email to Employee
            var EmployeeEmail = Employee.Employee_Email;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
            email.To.Add(MailboxAddress.Parse(EmployeeEmail));
            email.Subject = "Dear " + Employee.Employee_Name + " you have been successfully added to the employee database at Royal Hotel";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Greetings " + Employee.Employee_Name + ", You are now hired as a " + Employee.Employee_Designation + " at Royal Hotel." };

            using var smpt = new SmtpClient();
            smpt.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smpt.Authenticate("royal.hotel.ind@gmail.com", "bazkvpswtwzrkrzm");
            smpt.Send(email);
            smpt.Disconnect(true);
            #endregion

            return Ok("{\"msg\":\"New Employee Added\"}");
        }
        #endregion

        #region UpdateEmployee
        [HttpPut]
        [Route("/UpdateEmployee")]
        [Authorize(Roles = "owner")]

        //[Authorize]
        public IActionResult UpdateEmployee(int Employeeid, AddUpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            var CheckEmployee = dbContext.Employees.Find(Employeeid);

            if (CheckEmployee != null)
            {
                CheckEmployee.Employee_Email = updateEmployeeWithoutId.Employee_Email;
                CheckEmployee.Employee_PhoneNo = updateEmployeeWithoutId.Employee_PhoneNo;
                CheckEmployee.Employee_Designation = updateEmployeeWithoutId.Employee_Designation;
                CheckEmployee.Employee_Name = updateEmployeeWithoutId.Employee_Name;
                CheckEmployee.Employee_Address = updateEmployeeWithoutId.Employee_Address;
                CheckEmployee.Employee_Age = updateEmployeeWithoutId.Employee_Age;
                CheckEmployee.Employee_Password = updateEmployeeWithoutId.Employee_Password;
                CheckEmployee.Employee_Salary = updateEmployeeWithoutId.Employee_Salary;

                dbContext.SaveChanges();
                return Ok("{\"msg\":\"Employee Update\"}");
            }
            return Ok("{\"msg\":\"Employee not found\"}");
        }
        #endregion

        #region DeleteEmployee
        [HttpDelete]
        [Route("/DeleteEmployee")]
        [Authorize(Roles = "owner")]

        //[Authorize]
        public IActionResult DeleteEmployee( int Employeeid)
        {
            var CheckEmployee = dbContext.Employees.Find(Employeeid);

            if (CheckEmployee != null)
            {
                dbContext.Employees.Remove(CheckEmployee);
                dbContext.SaveChanges();

                #region Email to Employee
                var EmployeeEmail = CheckEmployee.Employee_Email;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("royal.hotel.ind@gmail.com"));
                email.To.Add(MailboxAddress.Parse(EmployeeEmail));
                email.Subject = "Dear " + CheckEmployee.Employee_Name + " , Thank you for your service at Royal Hotel";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = " Thank you, " + CheckEmployee.Employee_Name + ", for your service as a " + CheckEmployee.Employee_Designation + " at Royal Hotel." };

                using var smpt = new SmtpClient();
                smpt.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smpt.Authenticate("royal.hotel.ind@gmail.com", "bazkvpswtwzrkrzm");
                smpt.Send(email);
                smpt.Disconnect(true);
                #endregion

                return Ok("{\"msg\":\"Employee Deleted\"}");
            }
            return Ok("{\"msg\":\"Employee not found\"}");
        }
        #endregion

        #region AllRooms
        [HttpGet]
        [Route("/AllRooms")]
        //[Authorize]
        public IActionResult GetRoom()
        {
            return Ok(dbContext.Rooms.ToList());
        }
        #endregion

        #region AllGuests
        [HttpGet]
        [Route("/AllGuests")]
        //[Authorize]
        public IActionResult GetGuest()
        {
            return Ok(dbContext.Guests.ToList());
        }
        #endregion
    }
}
