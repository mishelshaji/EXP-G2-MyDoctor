using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class ApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public async Task<ServiceResponse<bool>> PostData(RegisterDto dto)
        {
            var response = new ServiceResponse<bool>();
            var user = new ApplicationUser()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Specialization = dto.Specialization,
                UserName = Guid.NewGuid().ToString()
            };

            if (dto.Role == "Doctor" || dto.Role == "Patient")
            {
                var UserStatus = await _userManager.CreateAsync(user, dto.Password);
                if (!UserStatus.Succeeded)
                {
                    response.AddError("", "Failed to add items");
                    return response;
                }
                var rolestatus = await _userManager.AddToRoleAsync(user, dto.Role);
                return response;
            }
            response.AddError("", "Role is not correct");
            return response;
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
            var signin = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (signin.Succeeded)
            {
                response.Result= GenerateToken(user);
                return response;
            }
            response.AddError("", "Not logined");
            return response;
        }

        public string GenerateToken(ApplicationUser user)
        {
            string key = _configuration["Jwt:Key"];
            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, "HS256");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow + TimeSpan.FromDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
