using Identity.Common.BaseResponse;
using Identity.Common.User;
namespace Identity.Application.Interfaces;
public interface IUserManagementService
{
    Task<BaseResponse<UserDto>> CreateUser(CreateUserDto user);
    Task<BaseResponse<List<UserDto>>> GetUsers();
    Task<BaseResponse<UserDto>> GetUser(long id);
    Task<BaseResponse<UserDto>> UpdateUser(long id, UpdateUserDto user);
    Task<BaseResponse<bool>> DeleteUser(long id);
    Task<BaseResponse<bool>> AssignRoleToUser(long userId, string roleName);
    Task<BaseResponse<bool>> RemoveRoleFromUser(long userId, string roleName);
}


