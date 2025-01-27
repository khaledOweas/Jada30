using Domain;
using Framework;
using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class PermissionManagementService : IPermissionManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Permission>> CreatePermission(Permission permission)
        {
           await _unitOfWork.GetRepository<Permission>().InsertAsync(permission);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse<Permission>("Permission created successfully.", permission);
        }
    }

}
