using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueSystem_BE.Common.Constants;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        // NOTE: Spec says /api/items; keeping InventoryController as requested folder list.
        // TODO: consider adding ItemsController that routes /api/items and delegating here.

        [HttpGet("items")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult GetItems() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost("items")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult CreateItem() => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPut("items/{id:int}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult UpdateItem(int id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpDelete("items/{id:int}")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult DeleteItem(int id) => StatusCode(StatusCodes.Status501NotImplemented);

        [HttpPost("items/{id:int}/import")]
        [Authorize(Roles = $"{RoleCodes.MANAGER},{RoleCodes.ADMIN}")]
        public IActionResult ImportStock(int id) => StatusCode(StatusCodes.Status501NotImplemented);
    }
}

