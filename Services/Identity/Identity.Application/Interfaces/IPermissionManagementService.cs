using Identity.Common.BaseResponse;
using Identity.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IPermissionManagementService
    {
        Task<BaseResponse<Permission>> CreatePermission(Permission permission);
    }

}
