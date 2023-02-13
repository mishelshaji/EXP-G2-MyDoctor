using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Drawing.Text;

namespace MyDoctor.WebApp.Areas.User.Controllers
{
    public class AccountsController : AdminBaseController
    {
        private readonly ApplicationUserService service;

        public AccountsController(ApplicationUserService Service)
        {
            service = Service;
        }
        [HttpPost]
        public async Task<IActionResult> PostData(RegisterDto dto)
        {
            var res = await service.PostData(dto);
            return Ok(res);
        }
    }
}
