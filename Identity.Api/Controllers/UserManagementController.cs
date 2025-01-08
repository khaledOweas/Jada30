using Identity.Common.BaseResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.Infrastructure.Models;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserManagementController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Create a new user
        [HttpPost("users")]
        public async Task<BaseResponse<ApplicationUser>> CreateUser([FromBody] ApplicationUser user, string password)
        {
            var response = new BaseResponse<ApplicationUser>();
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                response = new SuccessResponse<ApplicationUser>("Create user Successfully Done ", user);
            }
            response = new FailedResponse<ApplicationUser>("Failed While Create User ", new List<Errors>());

            return response;
        }

        // Get all users
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users;
            return Ok(users);
        }

        // Get a user by ID
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Update a user
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] ApplicationUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            // Update other properties as needed

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return Ok(existingUser);
            }
            return BadRequest(result.Errors);
        }

        // Delete a user
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
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

        // Assign a role to a user
        [HttpPost("users/{userId}/roles/{roleName}")]
        public async Task<IActionResult> AssignRoleToUser(long userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found");
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return NotFound("Role not found");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        // Remove a role from a user
        [HttpDelete("users/{userId}/roles/{roleName}")]
        public async Task<IActionResult> RemoveRoleFromUser(long userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        // Create a new role
        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] ApplicationRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            }
            return BadRequest(result.Errors);
        }

        // Get all roles
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }
    }

}
