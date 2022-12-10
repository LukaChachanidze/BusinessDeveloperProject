using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers()
        { 
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
      
        [HttpPost(nameof(CreateUser))]
        public async Task<ActionResult<ApplicationUser>> CreateUser(CreateUserRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("update")]
        public async Task<ActionResult<ApplicationUser>> UpdateUser([FromBody] UpdateUserRequest model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return user;
        }

        
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}

