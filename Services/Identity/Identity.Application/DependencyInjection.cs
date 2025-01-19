using Identity.Application.Interfaces;
using Identity.Application.Services;
using Identity.Framework.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPermissionManagementService, PermissionManagementService>();
            services.AddTransient<IRoleManagementService, RoleManagementService>();
            services.AddTransient<IUserManagementService, UserManagementService>();

            return services;
        }
    }
}
