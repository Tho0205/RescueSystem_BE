using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/teams/{teamId:guid}/members")]
    public class TeamMembersController : ControllerBase
    {
        // TODO: inject ITeamMembersService

        [HttpPost]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult AddMember(Guid teamId) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("{userId:guid}")]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult RemoveMember(Guid teamId, Guid userId) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPatch("{userId:guid}/leader")]
        [Authorize(Roles = $"{RoleCodes.ADMIN},{RoleCodes.MANAGER}")]
        public IActionResult SetLeader(Guid teamId, Guid userId) => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

