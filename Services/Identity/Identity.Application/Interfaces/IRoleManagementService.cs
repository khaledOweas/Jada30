using Domain;
using Identity.Common.BaseResponse;
using Identity.Common.Permission;
using Identity.Common.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IRoleManagementService
    {
        Task<BaseResponse<bool>> CreateRole(ApplicationRole role);
        BaseResponse<List<RoleDto>> GetRoles();
        Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId);
        Task<BaseResponse<List<GetPermissionDto>>> GetPermissionsForRole(long roleId);
        Task<BaseResponse<bool>> CreateRoleWithPermissions(CreateRoleWithPermssionsDto req);
    }

}
