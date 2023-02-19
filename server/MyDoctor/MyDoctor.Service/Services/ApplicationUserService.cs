using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Html;
using System.Net;

namespace MyDoctor.Service.Services
{
    public class ApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        public int otp;

        public ApplicationUserService(UserManager<ApplicationUser> userManager,
                                      RoleManager<IdentityRole> roleManager,
                                      IConfiguration configuration,
                                      SignInManager<ApplicationUser> signInManager,
                                      ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _db = db;
        }
        public async Task<ServiceResponse<bool>> PostData(RegisterDto dto)
        {
            var response = new ServiceResponse<bool>();
            if ("704144" == dto.otp)
            {
                var user = new ApplicationUser()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Specialization = dto.Specialization,
                    UserName = Guid.NewGuid().ToString()
                };

                if (dto.Role == "Patient")
                {
                    var UserStatus = await _userManager.CreateAsync(user, dto.Password);
                    if (!UserStatus.Succeeded)
                    {
                        response.AddError("", "Failed to add items");
                        return response;
                    }
                    var rolestatus = await _userManager.AddToRoleAsync(user, dto.Role);
                    var id = await _userManager.FindByEmailAsync(dto.Email);
                    var user2 = new PatientsMaster()
                    {
                        ApplicationUserId = id.Id
                    };
                    _db.PatientsMaster.Add(user2);
                    _db.SaveChanges();
                    return response;
                }
                else if(dto.Role == "Doctor")
                {
                    var UserStatus = await _userManager.CreateAsync(user, dto.Password);
                    if (!UserStatus.Succeeded)
                    {
                        response.AddError("", "Failed to add items");
                        return response;
                    }
                    var rolestatus = await _userManager.AddToRoleAsync(user, dto.Role);
                    var id = await _userManager.FindByEmailAsync(dto.Email);
                    var deptId =  _db.Department.Where(m => m.DepartmentName == dto.Specialization).Select(m => m.Id).FirstOrDefault();
                    var user2 = new DoctorMaster()
                    {
                        ApplicationUserId = id.Id,
                        DepartmentName = dto.Specialization,
                        DepartmentId = deptId
                    };
                    _db.DoctorMaster.Add(user2);
                    _db.SaveChanges();
                    return response;
                }

                response.AddError("", "Role is not correct");
                return response;
            }
            else
            {
                response.AddError("", "Incorrect Otp");
                return response;
            }
        }
        public async Task<ServiceResponse<string>> login(LoginDto dto)
        {
            var response = new ServiceResponse<string>();
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                response.AddError(nameof(dto.Email), "Email not found");
                return response;
            }

            var signin = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (signin.Succeeded)
            {
                response.Result= GenerateToken(user);
                return response;
            }

            response.AddError("", "Not able to login");
            return response;
        }

        public string GenerateToken(ApplicationUser user)
        {
            string key = _configuration["Jwt:Key"];
            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];

            var role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().First();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, "HS256");
            List<int> master = null;
            if(role == "Patient") 
            {
                master = _db.PatientsMaster.Where(m => m.ApplicationUserId == user.Id).Select(c => c.Id).ToList();
            }
            else if(role == "Doctor")
            {
                master = _db.DoctorMaster.Where(m => m.ApplicationUserId == user.Id).Select(c => c.Id).ToList();
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, role),
                new Claim("Role", role),
                new Claim("UserId", user.Id),
                new Claim("MasterId", master[0].ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                audience: audience,
                expires: DateTime.UtcNow + TimeSpan.FromDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ServiceResponse<bool>> SendOtp(RegisterDto Receiver)
        {
            var response = new ServiceResponse<bool>();
            //creating the message in which we store message details
           MimeMessage message = new MimeMessage();
            //details of sender
            message.From.Add(new MailboxAddress("Admin", "mydonorservice@gmail.com"));
            // details of reciever
            message.To.Add(new MailboxAddress("user", "rashirashidka2@gmail.com"));
            Random Random = new Random();
            otp = 704144;
            //email subject
            message.Subject = "MyDoctor OTP for Registration";
            //body of email
            message.Body = new TextPart("plain")
            {
                Text = @$" Welcome to Mydoctor Patient management Service.
                        OTP for MyDoctor website is - {otp}.
                        We Are Here To Help You With Any Kind Of Support
                        In Case Of Emergency.Feel Free To Contact Us."
            };

            string Email = "mydonorservice@gmail.com";
            string password = "yvtd hrkg gwtf utoh";

            // creating a mail client
            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                // connecting to gmail smtp and using the 465 port and ssl enabled is true.
                client.Connect("smtp.gmail.com", 587);
                // Authenticate sender using email and password.
                client.Authenticate(Email, password);
                client.Send(message);
            }
            catch (Exception ex)
            {
                // if any exception
                response.AddError("", "Otp problem");
                return response;
            }
            finally
            {
                // disconnect the client
                client.Disconnect(true);
                // dispose client object
                client.Dispose();
            }
            return response;
        }
    }
}
