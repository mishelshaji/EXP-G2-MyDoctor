using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    public class PatientAppointmentsController: BaseController
    {
        private readonly AppointmentBookingService _appointmentBookingService;

        public PatientAppointmentsController(AppointmentBookingService appointmentBookingService)
        {
            _appointmentBookingService= appointmentBookingService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingData(int id)
        {
            var res = await _appointmentBookingService.GetBookingData(id);
            return Ok(res);
        }
    }
}
