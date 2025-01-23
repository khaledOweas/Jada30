using AutoMapper;
using AutoMapper.QueryableExtensions;

using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Common.Role;
using Identity.Common.User;
using Identity.Infrastructure.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;

        }

        public async Task<BaseResponse<UserDto>> CreateUser(CreateUserDto user)
        {
            var userEntity = new ApplicationUser
            {
                UserNameAr = user.UserNameAr,
                UserName = user.UserName,
                Email = user.Email,
                NormalizedEmail = user.Email?.ToUpper(),
                NormalizedUserName = user.UserName?.ToUpper(),
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = false
            };

            var result = await _userManager.CreateAsync(userEntity, user.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList();
                return new FailedResponse<UserDto>("Failed to create user.", errors);
            }

            foreach (var role in user.RoleNames.Where(role => !string.IsNullOrWhiteSpace(role)))
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    return new FailedResponse<UserDto>("Role does not exist.");
                }

                await _userManager.AddToRoleAsync(userEntity, role);
            }
            var userDto = _mapper.Map<UserDto>(userEntity);


            return new SuccessResponse<UserDto>("User created successfully.", userDto);
        }

        public async Task<BaseResponse<List<UserDto>>> GetUsers()
        {

            var applicationUsers = await _userManager.Users.ToListAsync();

            var userDtos = _mapper.Map<List<UserDto>>(applicationUsers);

            for (var i = 0; i < applicationUsers.Count; i++)
            {
                var user = applicationUsers[i];
                var roles = await _userManager.GetRolesAsync(user);

                var userRoles = await _roleManager.Roles
                    .AsNoTracking()
                    .Where(x => roles.Contains(x.Name))
                    .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                userDtos[i].Roles = userRoles;
            }

            return new SuccessResponse<List<UserDto>>("Users retrieved successfully.", userDtos);
        }
        public async Task<BaseResponse<UserDto>> GetUser(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userDto = _mapper.Map<UserDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            var userRoles = await _roleManager.Roles
                .AsNoTracking()
                .Where(x => roles.Contains(x.Name))
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            userDto.Roles = userRoles;
            return userDto == null
                ? new FailedResponse<UserDto>("User not found.")
                : new SuccessResponse<UserDto>("User retrieved successfully.", userDto);
        }

        public async Task<BaseResponse<UserDto>> UpdateUser(long id, UpdateUserDto user)
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return new FailedResponse<UserDto>("User not found.");
            } 
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.UserNameAr = user.UserNameAr ?? "";

            var result = await _userManager.UpdateAsync(existingUser);
            var userDto = _mapper.Map<UserDto>(existingUser);
            return result.Succeeded
                ? new SuccessResponse<UserDto>("User updated successfully.", userDto)
                : new FailedResponse<UserDto>("Failed to update user.", result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList());
        }

        public async Task<BaseResponse<bool>> DeleteUser(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new FailedResponse<bool>("User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded
                ? new SuccessResponse<bool>("User deleted successfully.", true)
                : new FailedResponse<bool>("Failed to delete user.", result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList());
        }

        public async Task<BaseResponse<bool>> AssignRoleToUser(long userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new FailedResponse<bool>("User not found.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return new FailedResponse<bool>("Role not found.");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded
                ? new SuccessResponse<bool>("Role assigned successfully.", true)
                : new FailedResponse<bool>("Failed to assign role.", result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList());
        }

        public async Task<BaseResponse<bool>> RemoveRoleFromUser(long userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new FailedResponse<bool>("User not found.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded
                ? new SuccessResponse<bool>("Role removed successfully.", true)
                : new FailedResponse<bool>("Failed to remove role.", result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList());
        }
    }

}
