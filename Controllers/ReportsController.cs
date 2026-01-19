using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
    public class ReportsController : ControllerBase
    {
        // TODO: inject IReportsService

        [HttpGet("requests")]
        public IActionResult RequestsReport() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("missions")]
        public IActionResult MissionsReport() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("inventory")]
        public IActionResult InventoryReport() => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

