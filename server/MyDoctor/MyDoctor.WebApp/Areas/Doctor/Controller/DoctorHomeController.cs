using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDoctor.WebApp.Areas.Doctor.Controller
{
    public class DoctorHomeController : DoctorBaseController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> DoctorAppointment(string id)
        {

            return Ok();
        }
    }
}
