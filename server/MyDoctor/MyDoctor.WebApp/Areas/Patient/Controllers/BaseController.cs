using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDoctor.WebApp.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }
}
