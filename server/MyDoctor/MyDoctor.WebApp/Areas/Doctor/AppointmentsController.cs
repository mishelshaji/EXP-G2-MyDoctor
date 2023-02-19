using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Doctor
{
    public class AppointmentsController : DoctorBaseController
    {
        private readonly DoctorService _doctorService;

        public AppointmentsController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AppointmentDoctorDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorAppointments(int id)
        {
            var res = await _doctorService.GetDoctorAppointmentsAsync(id);
            return Ok(res);
        }
    }
}
