using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        // TODO: inject IVehiclesService

        [HttpGet]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult GetVehicles() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult CreateVehicle() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPut("{id:int}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult UpdateVehicle(int id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("{id:int}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult DeleteVehicle(int id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPatch("{id:int}/status")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult UpdateStatus(int id) => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

