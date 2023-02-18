using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Security.Claims;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly PatientService _patientService;

        public AppointmentController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PatientAppointmentsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAppointmentHistory()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _patientService.GetAppointmentHistoryAsync(id);
            return Ok(res);
        }
    }
}
