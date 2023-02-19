using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Security.Claims;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly PatientService _patientService;
        private readonly AppointmentBookingService _appointmentBookingService;

        public AppointmentController(PatientService patientService,
                                     AppointmentBookingService appointmentBookingService)
        {
            _patientService = patientService;
            _appointmentBookingService = appointmentBookingService;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingData(int id)
        {
            var res = await _appointmentBookingService.GetBookingData(id);
            return Ok(res);
        }

        [HttpGet("{id}/{date}")]
        [ProducesResponseType(typeof(PatientAppointmentsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTimeSlots(int id,string date)
        {
            var res = await _appointmentBookingService.GetTimeSlots(id, date);
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PatientAppointmentsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddBookings(AddBookingDto dto)
        {
            var res = await _appointmentBookingService.AddBookings(dto);
            return Ok(res);
        }
    }
}
