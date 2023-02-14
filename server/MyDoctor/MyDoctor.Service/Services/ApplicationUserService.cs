using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Identity;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Service.Services
{
    public class ApplicationUserService
    {
        public Dictionary<string, string> diccccc = new();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.diccccc.Add("email", "rashid");
            this.diccccc.Add("password", "helloqorld");
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<ServiceResponse<bool>> PostData(RegisterDto dto)
        {
            var response = new ServiceResponse<bool>();
            var user = new ApplicationUser()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Specilization = dto.Specalization,
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
        public async Task<LoginDto> GetDataByEmail(LoginDto dto)
        {
            if(dto.Email == this.diccccc["email"]) {
                var obj = new LoginDto();
                obj.Email = this.diccccc["email"];
                obj.Password = this.diccccc["password"];
                return obj;
            }
            return new LoginDto(); 
        }
    }
}
