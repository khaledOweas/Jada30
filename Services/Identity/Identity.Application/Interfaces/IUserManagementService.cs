using Identity.Common.BaseResponse;
using Identity.Common.User;
using Identity.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IUserManagementService
    {
        Task<BaseResponse<ApplicationUser>> CreateUser(CreateUserDto user);
        Task<BaseResponse<List<UserDto>>> GetUsers();
        Task<BaseResponse<ApplicationUser>> GetUser(long id);
        Task<BaseResponse<ApplicationUser>> UpdateUser(long id, ApplicationUser user);
        Task<BaseResponse<bool>> DeleteUser(long id);
        Task<BaseResponse<bool>> AssignRoleToUser(long userId, string roleName);
        Task<BaseResponse<bool>> RemoveRoleFromUser(long userId, string roleName);
    }

}
