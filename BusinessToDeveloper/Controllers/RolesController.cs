using BusinessToDeveloper.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
       [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return roles;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IdentityRole>> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Role name is required.");
            }

            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return role;
        }

        [HttpDelete("{roleName}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("{roleName}/users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddUserToRole(string roleName, string userId)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpDelete("{roleName}/users/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveUserFromRole(string roleName, string userId)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}

