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
        public async Task<IActionResult> PostData(RegisterDto dto)
        {
            var res = await _service.PostData(dto);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmail(LoginDto dto)
        {
            var res = await _service.GetDataByEmail(dto);
            return Ok(res);
        }
    }
}
