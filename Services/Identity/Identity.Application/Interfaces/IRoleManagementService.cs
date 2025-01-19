using Identity.Common.BaseResponse;
using Identity.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IRoleManagementService
    {
        Task<BaseResponse<ApplicationRole>> CreateRole(ApplicationRole role);
        BaseResponse<List<ApplicationRole>> GetRoles();
        Task<BaseResponse<bool>> AssignPermissionToRole(long roleId, long permissionId);
        Task<BaseResponse<List<Permission>>> GetPermissionsForRole(long roleId);
    }

}
