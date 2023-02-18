using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Security.Claims;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
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
        [HttpPost]
        [ProducesResponseType(typeof(DoctorSearchResultDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorSearch(string searchValue)
        {
            var res = await _patientService.GetDoctorSearchAsync(searchValue);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PatientProfileDto[]), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PatientProfile(int id, PatientProfileDto dto)
        {
            var res = await _patientProfileService.EditPatientProfileAsync(id, dto);
            return Ok();
        }
    }
}
