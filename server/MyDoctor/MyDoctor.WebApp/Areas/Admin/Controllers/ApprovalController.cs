using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Admin.Controllers
{
    public class ApprovalController : BaseController
    {
        private readonly AdminService _adminService;

        public ApprovalController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("Registration")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNewDoctors()
        {
            var res = await _adminService.GetNewDoctorsAsync();
            return Ok(res);
        }

        [HttpPut("Registration/{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ApproveDoctor(int id)
        {
            var res = await _adminService.ApproveDoctorAsync(id);
            return Ok(res);
        }

        [HttpDelete("Registration/{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeclineDoctor(int id)
        {
            var res = await _adminService.DeclineDoctorAsync(id);
            return Ok(res);
        }

    }
}
