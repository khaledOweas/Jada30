using AutoMapper;
using Domain;
using Framework;
using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Common.Permission;
using Identity.Common.Role;

using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Services
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManagementService(IUnitOfWork unitOfWork, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<bool>> CreateRole(ApplicationRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new SuccessResponse<bool>("Role created successfully.", true);
            }

            var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
            return new FailedResponse<bool>("Failed to create role.");
        }

        public async Task<BaseResponse<bool>> CreateRoleWithPermissions(CreateRoleWithPermssionsDto req)
        {
            var checkRoleExists = await _roleManager.RoleExistsAsync(req.RoleName);
            if (checkRoleExists)
            {
                return new FailedResponse<bool>("Role already exists.");
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
                return new SuccessResponse<bool>("Role created successfully.", true);
            }

            var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
            return new FailedResponse<bool>("Failed to create role.");
        }

        public async Task<BaseResponse<List<GetPermissionDto>>> GetPermissionsForRole(long roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return new FailedResponse<List<GetPermissionDto>>("Role not found.");
            }

            var permissions = (await  _unitOfWork.GetRepository<RolePermission>().GetAllAsync(rp => rp.RoleId == roleId))
                .Select(rp => rp.Permission)
                .ToList();


            return new SuccessResponse<List<GetPermissionDto>>("Permissions retrieved successfully.", permissions.Select(p => _mapper.Map<GetPermissionDto>(p)).ToList());
        }

        public BaseResponse<List<RoleDto>> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return new SuccessResponse<List<RoleDto>>("Roles retrieved successfully.", _mapper.Map<List<RoleDto>>(roles));
        }
    }
}
