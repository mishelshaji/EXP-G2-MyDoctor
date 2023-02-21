using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Security.Claims;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly PatientService _patientService;
        private readonly DepartmentService _departmentService;
        private readonly PatientProfileService _patientProfileService;

        public HomeController(PatientService patientService,
            DepartmentService departmentService,
            PatientProfileService patientProfileService)
        {
            _patientService = patientService;
            _departmentService = departmentService;
            _patientProfileService = patientProfileService;
        }

        [Authorize(Roles = "Patient")]
        [HttpGet]
        [ProducesResponseType(typeof(DoctorSearchResultDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorSearch(string searchValue)
        {
            var res = await _patientService.GetDoctorSearchAsync(searchValue);
            return Ok(res);
        }

        [HttpPut("PatientProfileUpdate")]
        [ProducesResponseType(typeof(PatientProfileDto[]), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PatientProfileUpdate(PatientProfileDto dto)
        {
            var id2 = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Actor));
            Console.WriteLine(id2);
            var res = await _patientProfileService.EditPatientProfileAsync(id2, dto);
            return Ok(res);
        }

        [HttpGet("GetPatientProfile")]
        [ProducesResponseType(typeof(PatientProfileDto[]), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatientProfile()
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Actor));
            Console.WriteLine(id);
            var res = await _patientProfileService.GetPatientProfile(id);
            return Ok(res);
        }


        [HttpGet("DoctorDetails")]
        [ProducesResponseType(typeof(PatientDetailsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var res = await _patientService.GetDoctorDetailsAsync(id);
            return Ok(res);
        }

        [HttpGet("AppointmentDetails")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAppointmentDetailsForDoctors(int id)
        {
            var res = await _patientService.GetAppointmentDetailsForPatient(id);
            return Ok(res);
        }

        [HttpPut("cancelappointments")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelAppointments(int id)
        {
            var res = await _patientService.CancelAppointments(id);
            return Ok(res);
        }
    }
}
