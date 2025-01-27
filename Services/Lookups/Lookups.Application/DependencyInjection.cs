using Lookups.Application.Interfaces;
using Lookups.Application.Services;
using Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookups.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILookupService, LookupService>();
            return services;
        }
    }
}
