using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDoctor.WebApp.Areas.Doctor.Controller
{
    [Area("Doctor")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class DoctorBaseController : ControllerBase
    {
    }
}
