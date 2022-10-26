using HotelManagementSystem.Data;
using HotelManagementSystem.Dtos;
using HotelManagementSystem.Interface;
using HotelManagementSystem.Models;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HotelManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
        {
        private readonly HMSApiDbcontext dbContext;
        public EmployeeRepository(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetReceptionist
        public async Task<IEnumerable<Employee>> GetReceptionist()
        {
            return await dbContext.Employees.Where(x =>x.Employee_Designation == "Receptionist").ToListAsync();
        }

        #endregion

        #region AddReceptionist
        public async Task<Employee> AddReceptionist(AddUpdateEmployeeWithoutId addEmployeeWithoutId)
        {
            if(addEmployeeWithoutId != null) 
            {
            var Employee = new Employee()
            {
                Employee_Designation = "Receptionist",
                Employee_Name = addEmployeeWithoutId.Employee_Name,
                Employee_Password = addEmployeeWithoutId.Employee_Password,
                Employee_Salary = addEmployeeWithoutId.Employee_Salary,
                Employee_Email = addEmployeeWithoutId.Employee_Email,
                Employee_Age = addEmployeeWithoutId.Employee_Age,
                Employee_PhoneNo = addEmployeeWithoutId.Employee_PhoneNo,
                Employee_Address = addEmployeeWithoutId.Employee_Address,
            };

            await dbContext.Employees.AddAsync(Employee);
            await dbContext.SaveChangesAsync();

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
        }
            return null;
        }
        #endregion

        #region UpdateReceptionist
        public async Task<Employee> UpdateReceptionist( int Employeeid,AddUpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            var CheckEmployee = dbContext.Employees.Find(Employeeid);

            if(CheckEmployee != null)
            {
                if(CheckEmployee.Employee_Designation == "Receptionist")
                {
                    CheckEmployee.Employee_Email = updateEmployeeWithoutId.Employee_Email;
                    CheckEmployee.Employee_PhoneNo = updateEmployeeWithoutId.Employee_PhoneNo;
                    CheckEmployee.Employee_Designation = "Receptionist";
                    CheckEmployee.Employee_Name = updateEmployeeWithoutId.Employee_Name;
                    CheckEmployee.Employee_Address = updateEmployeeWithoutId.Employee_Address;
                    CheckEmployee.Employee_Age = updateEmployeeWithoutId.Employee_Age;
                    CheckEmployee.Employee_Password = updateEmployeeWithoutId.Employee_Password;
                    CheckEmployee.Employee_Salary = updateEmployeeWithoutId.Employee_Salary;

                    await dbContext.SaveChangesAsync();
                }
                return CheckEmployee;
            }

                return null;
        }

        #endregion

        #region DeleteReceptionist
        [HttpDelete]
        [Route("/DeleteReceptionist")]
        public async void DeleteReceptionist(int Employeeid)
        {
            var CheckEmployee = dbContext.Employees.Find(Employeeid);
            
            if(CheckEmployee != null)
            {
                if(CheckEmployee.Employee_Designation == "Receptionist")
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


                   // return CheckEmployee;

                }

               
            }
           // return NotFound("{\"msg\":\"No such employee found\"}");
        }
        #endregion
    }
}
