using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        // TODO: inject ITeamsService

        [HttpGet]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult GetTeams() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult CreateTeam() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPut("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult UpdateTeam(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult DeleteTeam(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("my")]
        [Authorize(Roles = RoleCodes.RESCUETEAM)]
        public IActionResult GetMyTeam() => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

