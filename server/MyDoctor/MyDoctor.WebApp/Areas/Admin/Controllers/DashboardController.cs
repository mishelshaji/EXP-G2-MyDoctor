using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly AdminService _adminService;

        public DashboardController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("PatientsCount")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatientsCount()
        {
            var res = await _adminService.GetPatientsCountAsync();
            return Ok(res);
        }

        [HttpGet("DoctorsCount")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDoctorsCount()
        {
            var res = await _adminService.GetDoctorsCountAsync();
            return Ok(res);
        }

        [HttpGet("UpcomingBookingsCount")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUpcomingBookingsCount()
        {
            var res = await _adminService.GetUpcomingBookingsCountAsync();
            return Ok(res);
        }

        [HttpGet("CompletedBookingsCount")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompletedBookingsCount()
        {
            var res = await _adminService.GetCompletedBookingsCountAsync();
            return Ok(res);
        }

        [HttpGet("RegistrationApprovalsCount")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRegistrationApprovalsCount()
        {
            var res = await _adminService.GetRegistrationApprovalsCountAsync();
            return Ok(res);
        }
    }
}
