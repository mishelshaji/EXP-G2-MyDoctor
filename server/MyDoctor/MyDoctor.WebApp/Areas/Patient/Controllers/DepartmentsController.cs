using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    public class DepartmentsController : BaseController
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("register")]
        [ProducesResponseType(typeof(DepartmentSuggestionDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentToRegister()
        {
            var res = await _departmentService.GetDepartmentSuggestionAsync();
            return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(DepartmentSuggestionDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentSuggestion()
        {
            var res = await _departmentService.GetDepartmentSuggestionAsync();
            return Ok(res);
        }
    }
}
