using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using MyDoctor.WebApp.Areas.User.Controllers;

namespace MyDoctor.WebApp.Areas.Admin.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDepartmentDetails()
        {
            var res = await _departmentService.GetAllDepartmentDetailsAsync();
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> AddNewDepartment(DepartmentAddDto departmentDetailsDto)
        {
            var res = await _departmentService.AddNewDepartmentAsync(departmentDetailsDto);
            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var res = await _departmentService.DeleteDepartmentAsync(id);
            return Ok(res);
        }


    }
}
