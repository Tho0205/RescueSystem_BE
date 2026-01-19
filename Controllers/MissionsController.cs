using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {
        // TODO: inject IMissionsService

        [HttpPost]
        [Authorize(Roles = RoleCodes.COORDINATOR)]
        public IActionResult CreateMission() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet]
        [Authorize(Roles = $"{RoleCodes.COORDINATOR},{RoleCodes.ADMIN}")]
        public IActionResult GetMissions() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("my")]
        [Authorize(Roles = RoleCodes.RESCUETEAM)]
        public IActionResult GetMyMissions() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("{id:guid}")]
        [Authorize]
        public IActionResult GetMission(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPatch("{id:guid}/start")]
        [Authorize(Roles = RoleCodes.RESCUETEAM)]
        public IActionResult Start(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPatch("{id:guid}/complete")]
        [Authorize(Roles = RoleCodes.RESCUETEAM)]
        public IActionResult Complete(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

