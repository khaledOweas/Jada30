using Identity.Infrastructure.Data;
using Identity.Infrastructure.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IdentityContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            try
            {

                // Clear existing data in the correct order to avoid foreign key conflicts
                context.RolePermissions.RemoveRange(context.RolePermissions); // Clear RolePermissions first
                context.Permissions.RemoveRange(context.Permissions); // Clear Permissions
                context.Users.RemoveRange(context.Users); // Clear Users
                context.Roles.RemoveRange(context.Roles); // Clear Roles

            }
            catch (Exception e)
            {
                await context.SaveChangesAsync(); // Save changes after clearing data
                Console.WriteLine(e);
                throw;
            }

            try
            {
                // Enable IDENTITY_INSERT only for tables with identity columns
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AspNetRoles ON"); // Enable for Roles
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AspNetUsers ON"); // Enable for Users

                // Seed Roles
                if (!await roleManager.Roles.AnyAsync())
                {
                    var roles = DefaultData.GetDefaultRoles();
                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                // Seed Users
                if (!await userManager.Users.AnyAsync())
                {
                    var users = DefaultData.GetDefaultUsers();
                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user);
                        await userManager.AddToRoleAsync(user, "Admin"); // Assign Admin role to the default user
                    }
                }

                // Seed Permissions (no IDENTITY_INSERT needed if Permissions table doesn't have an identity column)
                if (!context.Permissions.Any())
                {
                    var permissions = DefaultData.GetDefaultPermissions();
                    await context.Permissions.AddRangeAsync(permissions);
                    await context.SaveChangesAsync();
                }

                // Seed RolePermissions (no IDENTITY_INSERT needed if RolePermissions table doesn't have an identity column)
                if (!context.RolePermissions.Any())
                {
                    var rolePermissions = DefaultData.GetDefaultRolePermissions();
                    await context.RolePermissions.AddRangeAsync(rolePermissions);
                    await context.SaveChangesAsync();
                }
            }
            finally
            {
                // Disable IDENTITY_INSERT for tables with identity columns
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AspNetRoles OFF"); // Disable for Roles
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AspNetUsers OFF"); // Disable for Users
            }
        }
    }
}
