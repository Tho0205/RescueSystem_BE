using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueSyetem_BE.Models;
using RescueSystem_BE.Common.Constants;
using RescueSystem_BE.Dtos.Categories;

namespace RescueSystem_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly RescueSystemContext _context;

        public CategoriesController(RescueSystemContext context)
        {
            _context = context;
        }

        // GET /api/categories/roles
        [HttpGet("roles")]
        [Authorize(Roles = RoleCodes.ADMIN)]
        public async Task<ActionResult<IEnumerable<RoleCategoryDto>>> GetRoles()
        {
            var roles = await _context.Roles
                .AsNoTracking()
                .OrderBy(r => r.RoleId)
                .Select(r => new RoleCategoryDto
                {
                    RoleId = r.RoleId,
                    RoleCode = r.RoleCode,
                    RoleName = r.RoleName
                })
                .ToListAsync();

            return Ok(roles);
        }

        // GET /api/categories/urgency-levels
        [HttpGet("urgency-levels")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UrgencyLevelDto>> GetUrgencyLevels()
        {
            // 1-5, FE can show label, BE still validates numeric when implementing Requests
            var levels = new List<UrgencyLevelDto>
            {
                new() { Level = 1, Label = "Low" },
                new() { Level = 2, Label = "Moderate" },
                new() { Level = 3, Label = "High" },
                new() { Level = 4, Label = "Very High" },
                new() { Level = 5, Label = "Critical" }
            };

            return Ok(levels);
        }

        // GET /api/categories/item-categories
        [HttpGet("item-categories")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ItemCategoryDto>> GetItemCategories()
        {
            var categories = new List<ItemCategoryDto>
            {
                new() { Code = ItemCategoryCodes.FOOD, Name = "Food" },
                new() { Code = ItemCategoryCodes.MEDICAL, Name = "Medical" },
                new() { Code = ItemCategoryCodes.WATER, Name = "Water" },
                new() { Code = ItemCategoryCodes.CLOTHING, Name = "Clothing" },
                new() { Code = ItemCategoryCodes.SHELTER, Name = "Shelter" },
                new() { Code = ItemCategoryCodes.OTHER, Name = "Other" }
            };

            return Ok(categories);
        }
    }
}

