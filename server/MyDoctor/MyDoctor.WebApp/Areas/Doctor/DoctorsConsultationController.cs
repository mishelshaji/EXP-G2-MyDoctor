
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Doctor
{
    public class DoctorsConsultationController : DoctorBaseController
    {
        private readonly DoctorService _doctorService;

        public DoctorsConsultationController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [Authorize]
        [HttpGet("PatientDetails")]
        [ProducesResponseType(typeof(PatientDetailsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var res = await _doctorService.GetPatientDetailsAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPut("Prescription")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePrescription(int id, PrescriptionDto dto)
        {
            var res = await _doctorService.UpdatePrescriptionAsync(id, dto);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("AppointmentDetails")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAppointmentDetailsForDoctors(int id)
        {
            var res = await _doctorService.GetAppointmentDetailsForDoctors(id);
            return Ok(res);
        }
    }
}
