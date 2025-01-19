using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Framework.UoW;
using Identity.Infrastructure.Migrations;
using Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
