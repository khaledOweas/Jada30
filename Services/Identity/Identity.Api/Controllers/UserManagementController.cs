using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Common.Role;
using Identity.Common.User;
using Identity.Infrastructure.Models;

using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userService;
        private readonly IRoleManagementService _roleService;
        private readonly IPermissionManagementService _permissionService;

        public UserManagementController(IUserManagementService userService, IRoleManagementService roleService, IPermissionManagementService permissionService)
        {
            _userService = userService;
            _roleService = roleService;
            _permissionService = permissionService;
        }

        // User Endpoints
        [HttpPost("users")]
        public async Task<BaseResponse<UserDto>> CreateUser([FromBody] CreateUserDto user)
            => await _userService.CreateUser(user);

        [HttpGet("users")]
        public async Task<BaseResponse<List<UserDto>>> GetUsers()
            => await _userService.GetUsers();

        [HttpGet("users/{id}")]
        public async Task<BaseResponse<UserDto>> GetUser(long id)
            => await _userService.GetUser(id);

        [HttpPut("users/{id}")]
        public async Task<BaseResponse<UserDto>> UpdateUser(long id, [FromBody] UpdateUserDto user)
            => await _userService.UpdateUser(id, user);

        [HttpDelete("users/{id}")]
        public async Task<BaseResponse<bool>> DeleteUser(long id)
            => await _userService.DeleteUser(id);

        [HttpPost("users/{userId}/roles/{roleName}")]
        public async Task<BaseResponse<bool>> AssignRoleToUser(long userId, string roleName)
            => await _userService.AssignRoleToUser(userId, roleName);

        [HttpDelete("users/{userId}/roles/{roleName}")]
        public async Task<BaseResponse<bool>> RemoveRoleFromUser(long userId, string roleName)
            => await _userService.RemoveRoleFromUser(userId, roleName);


        [HttpPost("roles")]
        public async Task<BaseResponse<ApplicationRole>> CreateRole([FromBody] ApplicationRole role)
            => await _roleService.CreateRole(role);

        [HttpGet("roles")]
        public BaseResponse<List<ApplicationRole>> GetRoles()
            => _roleService.GetRoles();

        [HttpPost("roles/{roleId}/permissions/{permissionId}")]
        public async Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId)
            => await _roleService.AssignPermissionToRole(roleId, permissionId);

        [HttpGet("roles/{roleId}/permissions")]
        public async Task<BaseResponse<List<Permission>>> GetPermissionsForRole(long roleId)
            => await _roleService.GetPermissionsForRole(roleId);

        // Permission Endpoints
        [HttpPost("permissions")]
        public async Task<BaseResponse<Permission>> CreatePermission([FromBody] Permission permission)
            => await _permissionService.CreatePermission(permission);

        [HttpPost("CreateRoleWithPermissions")]
        public async Task<BaseResponse<ApplicationRole>> CreateRoleWithPermissions(CreateRoleWithPermssionsDto req )
            => await _roleService.CreateRoleWithPermissions(req);
    }

}
