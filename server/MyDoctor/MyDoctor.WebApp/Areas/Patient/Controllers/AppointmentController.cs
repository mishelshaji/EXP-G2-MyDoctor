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
        public AppointmentController() { }
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(PatientAppointmentsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorSearch(string searchValue)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _patientService.GetDoctorSearchAsync(id, searchValue);
            return Ok(res);
        }
    }
}
