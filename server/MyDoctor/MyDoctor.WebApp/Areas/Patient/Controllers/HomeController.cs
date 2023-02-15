using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PatientService _patientService;
        private readonly DepartmentService _departmentService;

        public HomeController(PatientService patientService, DepartmentService departmentService) 
        {
            _patientService = patientService;
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> PatientHomeSearch(string SearchValue)
        {
            var res = await _patientService.PatientHomeSearch(SearchValue);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentSuggestion()
        {
            var res = await _departmentService.GetDepartmentSuggestion();
            return Ok(res);
        }
    }
}
