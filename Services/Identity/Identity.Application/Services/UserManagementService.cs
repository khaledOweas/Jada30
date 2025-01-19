using Identity.Application.Interfaces;
using Identity.Common.BaseResponse;
using Identity.Common.User;
using Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse<ApplicationUser>> CreateUser(CreateUserDto user)
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
                return new FailedResponse<ApplicationUser>("Failed to create user.", errors);
            }

            foreach (var role in user.RoleNames.Where(role => !string.IsNullOrWhiteSpace(role)))
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    return new FailedResponse<ApplicationUser>("Role does not exist.");
                }

                await _userManager.AddToRoleAsync(userEntity, role);
            }

            return new SuccessResponse<ApplicationUser>("User created successfully.", userEntity);
        }

        public async Task<BaseResponse<List<UserDto>>> GetUsers()
        {
            var users = _userManager.Users.ToList();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result.ToList()
            }).ToList();

            return new SuccessResponse<List<UserDto>>("Users retrieved successfully.", userDtos);
        }

        public async Task<BaseResponse<ApplicationUser>> GetUser(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user == null
                ? new FailedResponse<ApplicationUser>("User not found.")
                : new SuccessResponse<ApplicationUser>("User retrieved successfully.", user);
        }

        public async Task<BaseResponse<ApplicationUser>> UpdateUser(long id, ApplicationUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return new FailedResponse<ApplicationUser>("User not found.");
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            var result = await _userManager.UpdateAsync(existingUser);
            return result.Succeeded
                ? new SuccessResponse<ApplicationUser>("User updated successfully.", existingUser)
                : new FailedResponse<ApplicationUser>("Failed to update user.", result.Errors.Select(e => new Errors { Key = e.GetHashCode(), Value = e.Description }).ToList());
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
