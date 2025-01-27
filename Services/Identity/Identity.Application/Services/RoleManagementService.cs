using Domain;
using Framework;
using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Common.Role;

using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Services
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManagementService(IUnitOfWork unitOfWork, RoleManager<ApplicationRole> roleManager)
        {
                _unitOfWork = unitOfWork;
                _roleManager = roleManager;
        }
        public Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ApplicationRole>> CreateRole(ApplicationRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new SuccessResponse<ApplicationRole>("Role created successfully.", role);
            }

            var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
            return new FailedResponse<ApplicationRole>("Failed to create role.", errors);
        }

        public async Task<BaseResponse<ApplicationRole>> CreateRoleWithPermissions(CreateRoleWithPermssionsDto req)
        {
            var checkRoleExists = await _roleManager.RoleExistsAsync(req.RoleName);
            if (checkRoleExists)
            {
                return new FailedResponse<ApplicationRole>("Role already exists.");
            }

            var role = new ApplicationRole
            {
                Name = req.RoleName,
                NormalizedName = req.RoleName,
                RolePermissions = req?.PermissionIds?.Select(p => new RolePermission { PermissionId = p }).ToList()
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new SuccessResponse<ApplicationRole>("Role created successfully.", role);
            }

            var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
            return new FailedResponse<ApplicationRole>("Failed to create role.", errors);
        }

        public async Task<BaseResponse<List<Permission>>> GetPermissionsForRole(long roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return new FailedResponse<List<Permission>>("Role not found.");
            }

            var permissions = (await  _unitOfWork.GetRepository<RolePermission>().GetAllAsync(rp => rp.RoleId == roleId))
                .Select(rp => rp.Permission)
                .ToList();

            return new SuccessResponse<List<Permission>>("Permissions retrieved successfully.", permissions);
        }

        public BaseResponse<List<ApplicationRole>> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return new SuccessResponse<List<ApplicationRole>>("Roles retrieved successfully.", roles);
        }
    }
}
