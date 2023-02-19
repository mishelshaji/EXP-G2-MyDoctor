using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Doctor
{
    public class ConsultationController : DoctorBaseController
    {
        private readonly DoctorService _doctorService;

        public ConsultationController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("PatientDetails")]
        [ProducesResponseType(typeof(PatientDetailsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var res = await _doctorService.GetPatientDetailsAsync(id);
            return Ok(res);
        }

        [HttpPut("Prescription")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePrescription(int id, PrescriptionDto dto)
        {
            var res = await _doctorService.UpdatePrescriptionAsync(id, dto);
            return Ok(res);
        }
    }
}
