using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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

        public HomeController(PatientService patientService,
            DepartmentService departmentService)
        {
            _patientService = patientService;
            _departmentService = departmentService;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatientHomeSearch(string searchValue)
        {
            var res = await _patientService.PatientHomeSearchAsync(searchValue);
            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PatientProfileDto[]), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PatientProfile(PatientProfileDto dto)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _patientService.EditPatientProfileAsync(dto, id, 1);
            return Ok(res);
        }
    }
}
