using Framework;
using Identity.Application.Services;
using Jada30Core.Application.Interfaces;
using Jada30Core.Application.Services;
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
            services.AddTransient<IFacilityManagementService, FacilityManagementService>();
            services.AddTransient<IBranchManagementService, BranchManagementService>();
            services.AddTransient<IPackageManagementService, PackageManagementService>();
            services.AddTransient<ISupportingServiceProviderManagementService, SupportingServiceProviderManagementService>();
            services.AddTransient<IPerkManagementService, PerkManagementService>();
            return services;
        }
    }
}
