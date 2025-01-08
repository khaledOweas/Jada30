
using Identity.Infrastructure.Models;

using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Seeding
{
    public static class DefaultData
    {
        public static List<ApplicationUser> GetDefaultUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            return new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        };
        }

        public static List<ApplicationRole> GetDefaultRoles()
        {
            return new List<ApplicationRole>
        {
            new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new ApplicationRole { Id = 2, Name = "User", NormalizedName = "USER" }
        };
        }

        public static List<Permission> GetDefaultPermissions()
        {
            return new List<Permission>
        {
            new Permission { Id = 1, Name = "CreateUser", Description = "Can create users" },
            new Permission { Id = 2, Name = "DeleteUser", Description = "Can delete users" },
            new Permission { Id = 3, Name = "EditUser", Description = "Can edit users" },
            new Permission { Id = 4, Name = "ViewUser", Description = "Can view users" }
        };
        }

        public static List<RolePermission> GetDefaultRolePermissions()
        {
            return new List<RolePermission>
        {
            new RolePermission { RoleId = 1, PermissionId = 1 }, // Admin can create users
            new RolePermission { RoleId = 1, PermissionId = 2 }, // Admin can delete users
            new RolePermission { RoleId = 1, PermissionId = 3 }, // Admin can edit users
            new RolePermission { RoleId = 1, PermissionId = 4 }, // Admin can view users
            new RolePermission { RoleId = 2, PermissionId = 4 }  // User can view users
        };
        }
    }
}
