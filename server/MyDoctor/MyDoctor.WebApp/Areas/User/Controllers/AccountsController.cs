using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Drawing.Text;

namespace MyDoctor.WebApp.Areas.User.Controllers
{
    public class AccountsController : AdminBaseController
    {
        private readonly ApplicationUserService _service;

        public AccountsController(ApplicationUserService Service)
        {
            _service = Service;
        }

        [HttpPost]
        public async Task<IActionResult> OtpGeneration(RegisterDto dto)
        {
            var res = _service.SendOtp(dto);
            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostData(RegisterDto dto)
        {
            var res = await _service.PostData(dto);
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto dto)
        {
            if (dto.Email == "admin@gmail.com" && dto.Password == "admin@12345")
            {
                var ress = await _service.AdminLogin(dto);
                return Ok(ress);
            }
            var res = await _service.login(dto);
            return Ok(res);
        }
    }
}
