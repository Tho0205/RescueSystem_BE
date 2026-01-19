using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributionsController : ControllerBase
    {
        // TODO: inject IDistributionsService

        [HttpGet]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult GetDistributions() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpGet("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult GetDistribution(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult CreateDistribution() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPut("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult UpdateDistribution(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult DeleteDistribution(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost("{id:guid}/details")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult AddDetail(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("{id:guid}/details/{itemId:int}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult RemoveDetail(Guid id, int itemId) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPatch("{id:guid}/deliver")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult Deliver(Guid id) => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

