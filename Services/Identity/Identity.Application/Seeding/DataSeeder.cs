
using Domain;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(Jada30Context context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {

            try
            {
                await SeedRoles(roleManager);
                await SeedUsers(userManager);
                await SeedPermission(context);
                await SeedSysConfig(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var users = DefaultData.GetDefaultUsers();
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user);
                    await userManager.AddToRoleAsync(user, user.UserName!);
                    // here to add all roles for super admin 
                    if (user.UserName.ToLower() == "superadmin")
                    {
                        var roles = DefaultData.GetDefaultRoles();
                        foreach (var role in roles)
                        {
                            await userManager.AddToRoleAsync(user, role.Name!);
                        }

                    }
                }
            }
        }

        public static async Task SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                var roles = DefaultData.GetDefaultRoles();
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

        }
        public static async Task SeedPermission(Jada30Context context)
        {
            if (!context.Permissions.Any())
            {
                var permissions = DefaultData.GetDefaultPermissions();
                await context.Permissions.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }

            if (!context.RolePermissions.Any())
            {
                var superAdminRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "SuperAdmin");
                var adminRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "Admin");
                var userRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "User");
                var guestRole = await context.Roles.FirstOrDefaultAsync(x => x.Name == "Guest");

                // Super Admin
                var allPermissions = context.Permissions.ToList();
                foreach (var permission in allPermissions)
                {
                    await context.RolePermissions.AddAsync(new RolePermission
                    {
                        RoleId = superAdminRole.Id,
                        PermissionId = permission.Id
                    });
                }

                // Guest 
                var guestPermissionsNames = new List<string>
                        {
                            "ViewMediaContent",
                            "ViewFacilities",
                            "ViewBasicPackages",
                            "ViewLongTermContracts",
                            "ViewAvailablePackagesAndContracts",
                            "ViewEventsAndSubscribe",
                            "RatePlatformPage",
                            "ViewFAQ",
                            "ContactUs",
                            "RequestBranchTour",
                            "RegisterAccount"

                        };

                var guestPermissions = allPermissions
                   .Where(p => guestPermissionsNames.Contains(p.Name))
                   .ToList();

                foreach (var permission in guestPermissions)
                {
                    await context.RolePermissions.AddAsync(new RolePermission
                    {
                        RoleId = guestRole.Id,
                        PermissionId = permission.Id
                    });
                }

                // User
                var userPermissionsNames = new List<string>
                        {
                            "Login",
                            "ChangePassword",
                            "ForgotPassword",
                            "SubscribeBasicPackage",
                            "SubscribeExtendedPackage",
                            "AddFacility",
                            "SubscribeVirtualOffice",
                            "SubscribeFeasibilityPlatform",
                            "SubscribeTools",
                            "SubscribePerks",
                            "SubscribeSupportServices",
                            "ManageCart",
                            "CompleteProfileBeforePayment",
                            "PaymentGateway",
                            "ViewActiveSubscriptions",
                            "ViewFacilitiesToReserve",
                            "ViewPackageConsumption",
                            "ViewBookingsTimeline",
                            "ViewBranchEvents",
                            "ViewOrEditUserData",
                            "RateJada30Services"

                        };

                var userPermissions = allPermissions
                    .Where(p => userPermissionsNames.Contains(p.Name))
                    .ToList();

                foreach (var permission in userPermissions)
                {
                    await context.RolePermissions.AddAsync(new RolePermission
                    {
                        RoleId = userRole.Id,
                        PermissionId = permission.Id
                    });
                }

                await context.SaveChangesAsync();
            }


        }
        public static async Task SeedSysConfig(Jada30Context context)
        {
            if (!context.SysConfigs.Any())
            {
                await context.SysConfigs.AddAsync(new SysConfig
                {
                    Key = "Master-Password",
                    Value = "P@ssw0rd"
                });
                await context.SaveChangesAsync();
            }
        }

    }
}
