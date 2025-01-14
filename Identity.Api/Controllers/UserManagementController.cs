using Identity.Common.BaseResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.Infrastructure.Models;
using Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Identity.Framework.Cache;
using Redis;
using Identity.Common.User;
using AutoMapper;
using Identity.Common.Role;
using Identity.Common.Permission;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IdentityContext _context;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public UserManagementController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IdentityContext context, ICacheService cacheService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        //
        // a new user 
        [HttpPost("users")]
        public async Task<BaseResponse<ApplicationUser>> CreateUser([FromBody] CreateUserDto user)
        {
            try
            {
                var userEntity = new ApplicationUser { UserName = user.UserName, Email = user.Email };
                var result = await _userManager.CreateAsync(userEntity, user.Password);
                if (result.Succeeded)
                {
                    return new SuccessResponse<ApplicationUser>("User created successfully.", userEntity);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<ApplicationUser>("Failed to create user.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<ApplicationUser>("An error occurred while creating the user.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        // Get all users
        [HttpPost("test")]
        public async Task<IActionResult> test()
        {
            var obj = await _cacheService.GetObject<string>("test");
            if(obj == null)
            {
                await _cacheService.SetObject("test", "test");
            }

            return Ok();
        }


        // Get all users
        [HttpGet("users")]
        public async Task<BaseResponse<List<ApplicationUser>>> GetUsers()
        {
            try
            {
                var users = _userManager.Users.ToList();
                return new SuccessResponse<List<ApplicationUser>>("Users retrieved successfully.", users);
            }
            catch (Exception ex)
            {
                return new FailedResponse<List<ApplicationUser>>("An error occurred while retrieving users.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpGet("users/{id}")]
        public async Task<BaseResponse<ApplicationUser>> GetUser(long id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return new FailedResponse<ApplicationUser>("User not found.");
                }

                return new SuccessResponse<ApplicationUser>("User retrieved successfully.", user);
            }
            catch (Exception ex)
            {
                return new FailedResponse<ApplicationUser>("An error occurred while retrieving the user.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }


        [HttpPut("users/{id}")]
        public async Task<BaseResponse<ApplicationUser>> UpdateUser(long id, [FromBody] UpdateUserDto user)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(id.ToString());
                if (existingUser == null)
                {
                    return new FailedResponse<ApplicationUser>("User not found.");
                }

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                // Update other properties as needed

                var result = await _userManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return new SuccessResponse<ApplicationUser>("User updated successfully.", existingUser);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<ApplicationUser>("Failed to update user.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<ApplicationUser>("An error occurred while updating the user.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<BaseResponse<bool>> DeleteUser(long id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return new FailedResponse<bool>("User not found.");
                }

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return new SuccessResponse<bool>("User deleted successfully.", true);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<bool>("Failed to delete user.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<bool>("An error occurred while deleting the user.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpPost("users/{userId}/roles/{roleName}")]
        public async Task<BaseResponse<bool>> AssignRoleToUser(long userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                {
                    return new FailedResponse<bool>("User not found.");
                }

                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    return new FailedResponse<bool>("Role not found.");
                }

                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return new SuccessResponse<bool>("Role assigned successfully.", true);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<bool>("Failed to assign role.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<bool>("An error occurred while assigning the role.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpDelete("users/{userId}/roles/{roleName}")]
        public async Task<BaseResponse<bool>> RemoveRoleFromUser(long userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                {
                    return new FailedResponse<bool>("User not found.");
                }

                var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return new SuccessResponse<bool>("Role removed successfully.", true);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<bool>("Failed to remove role.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<bool>("An error occurred while removing the role.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }


        [HttpPost("roles")]
        public async Task<BaseResponse<ApplicationRole>> CreateRole([FromBody] CreateRoleDto role)
        {
            try
            {
                var roleEntity = new ApplicationRole { Name = role.RoleName};
                var result = await _roleManager.CreateAsync(roleEntity);
                if (result.Succeeded)
                {
                    return new SuccessResponse<ApplicationRole>("Role created successfully.", roleEntity);
                }

                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<ApplicationRole>("Failed to create role.", errors);
            }
            catch (Exception ex)
            {
                return new FailedResponse<ApplicationRole>("An error occurred while creating the role.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpGet("roles")]
        public BaseResponse<List<ApplicationRole>> GetRoles()
        {
            try
            {
                var roles = _roleManager.Roles.ToList();
                return new SuccessResponse<List<ApplicationRole>>("Roles retrieved successfully.", roles);
            }
            catch (Exception ex)
            {
                return new FailedResponse<List<ApplicationRole>>("An error occurred while retrieving roles.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }



        #region Permissions

        [HttpPost("permissions")]
        public async Task<BaseResponse<Permission>> CreatePermission([FromBody] CreatePermissionDto permission)
        {
            try
            {
                var permissionEntity = _mapper.Map<Permission>(permission);
                _context.Permissions.Add(permissionEntity);
                await _context.SaveChangesAsync();
                return new SuccessResponse<Permission>("Permission created successfully.", permissionEntity);
            }
            catch (Exception ex)
            {
                return new FailedResponse<Permission>("An error occurred while creating the permission.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpPost("roles/{roleId}/permissions/{permissionId}")]
        public async Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                {
                    return new FailedResponse<bool>("Role not found.");
                }

                var permission = await _context.Permissions.FindAsync(permissionId);
                if (permission == null)
                {
                    return new FailedResponse<bool>("Permission not found.");
                }

                var rolePermission = new RolePermission { RoleId = roleId, PermissionId = permissionId };
                _context.RolePermissions.Add(rolePermission);
                await _context.SaveChangesAsync();

                return new SuccessResponse<bool>("Permission assigned to role successfully.", true);
            }
            catch (Exception ex)
            {
                return new FailedResponse<bool>("An error occurred while assigning the permission.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }

        [HttpGet("roles/{roleId}/permissions")]
        public async Task<BaseResponse<List<Permission>>> GetPermissionsForRole(long roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                {
                    return new FailedResponse<List<Permission>>("Role not found.");
                }

                var permissions = await _context.RolePermissions
                    .Where(rp => rp.RoleId == roleId)
                    .Select(rp => rp.Permission)
                    .ToListAsync();

                return new SuccessResponse<List<Permission>>("Permissions retrieved successfully.", permissions);
            }
            catch (Exception ex)
            {
                return new FailedResponse<List<Permission>>("An error occurred while retrieving permissions.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
            }
        }
        #endregion
    }

}
