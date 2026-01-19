using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        // TODO: inject IRequestsService

        [HttpPost]
        [Authorize(Roles = RoleCodes.CITIZEN)]
        public IActionResult CreateRequest()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("my")]
        [Authorize(Roles = RoleCodes.CITIZEN)]
        public IActionResult GetMyRequests()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public IActionResult GetRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}/confirm")]
        [Authorize(Roles = RoleCodes.CITIZEN)]
        public IActionResult ConfirmRescued(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleCodes.COORDINATOR},{RoleCodes.ADMIN}")]
        public IActionResult GetRequests([FromQuery] string? status = null, [FromQuery] int? urgency = null)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost("upload")]
        [Authorize(Roles = RoleCodes.CITIZEN)]
        public IActionResult Upload()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPatch("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.COORDINATOR},{RoleCodes.ADMIN}")]
        public IActionResult UpdateRequest(Guid id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}

