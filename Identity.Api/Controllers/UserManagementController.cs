using Identity.Common.BaseResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IdentityContext _context;

        public UserManagementController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IdentityContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        //
        // a new user 
        [HttpPost("users")]
        public async Task<BaseResponse<ApplicationUser>> CreateUser([FromBody] ApplicationUser user, string password)
        {
            var response = new BaseResponse<ApplicationUser>();
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    response = new SuccessResponse<ApplicationUser>("Create user Successfully Done ", user);
                }
                else
                {
                    var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                    response = new FailedResponse<ApplicationUser>("Failed While Create User ", errors);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Exception occurred: " + ex.Message);
                response = new FailedResponse<ApplicationUser>("An error occurred while creating the user", new List<Errors>());
            }

            return response;
        }

        // Get all users
        [HttpGet("users")]
        public BaseResponse<List<ApplicationUser>> GetUsers()
        {
            var users = _userManager.Users;
            return new SuccessResponse<List<ApplicationUser>>("Create user Successfully Done ", users.ToList());
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

        #region Permissions

        // Create a new permission
        [HttpPost("permissions")]
        public async Task<IActionResult> CreatePermission([FromBody] Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return Ok(permission);
        }

        // Assign a permission to a role
        [HttpPost("roles/{roleId}/permissions/{permissionId}")]
        public async Task<IActionResult> AssignPermissionToRole(long roleId, long permissionId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return NotFound("Role not found");
            }

            var permission = await _context.Permissions.FindAsync(permissionId);
            if (permission == null)
            {
                return NotFound("Permission not found");
            }

            var rolePermission = new RolePermission { RoleId = roleId, PermissionId = permissionId };
            _context.RolePermissions.Add(rolePermission);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Get all permissions for a role
        [HttpGet("roles/{roleId}/permissions")]
        public async Task<IActionResult> GetPermissionsForRole(long roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return NotFound("Role not found");
            }

            var permissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.Permission)
                .ToListAsync();

            return Ok(permissions);
        }

        #endregion
    }

}
