using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JWTTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly HMSApiDbcontext _context;
        public JWTTokenController(IConfiguration configuration, HMSApiDbcontext context)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Login with JWT
        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(string UserEmail, string Password, string UserType)
        {


            if (UserEmail == null || Password == null || UserType == null)
            {
                return NotFound("Invalid Credentials");
            }
            else
            {
                #region owner
                if (UserType.ToLower() == "owner")
                {
                    var userData = _context.Owners.FirstOrDefault(u => u.Owner_Email == UserEmail && u.Owner_Password == Password);
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                    if (userData != null)
                    {
                        var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "owner"),
                        new Claim("Id", UserEmail.ToString()),
                        new Claim("Password", Password)

                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                           jwt.Issuer,
                           jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                #endregion

                #region manager 

                if (UserType.ToLower() == "manager")
                {
                    var userData = _context.Employees.FirstOrDefault(u => u.Employee_Email == UserEmail && u.Employee_Password == Password && u.Employee_Designation.ToLower() == "manager");
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                    if (userData != null)
                    {
                        var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "manager"),
                        new Claim("Id", UserEmail.ToString()),
                        new Claim("Password", Password)

                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                           jwt.Issuer,
                           jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                #endregion

               #region receptionist
                if (UserType.ToLower() == "receptionists")
                {
                    var userData = _context.Employees.FirstOrDefault(u => u.Employee_Email == UserEmail && u.Employee_Password == Password && u.Employee_Designation.ToLower() == "receptionist");
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                    if (userData != null)
                    {
                        var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "receptionist"),
                        new Claim("Id", UserEmail.ToString()),
                        new Claim("Password", Password)

                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                           jwt.Issuer,
                           jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                #endregion

                return NotFound();
            }
            #endregion
            //return Ok("Login Successfull");

        }
    }
}