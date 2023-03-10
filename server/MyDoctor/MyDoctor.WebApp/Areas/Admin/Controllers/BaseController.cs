using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyDoctor.WebApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
