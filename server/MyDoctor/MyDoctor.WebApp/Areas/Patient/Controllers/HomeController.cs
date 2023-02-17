using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;

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

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatientHomeSearch(string searchValue)
        {
            var res = await _patientService.PatientHomeSearch(searchValue);
            return Ok(res);
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentSuggestion()
        {
            var res = await _departmentService.GetDepartmentSuggestion();
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
