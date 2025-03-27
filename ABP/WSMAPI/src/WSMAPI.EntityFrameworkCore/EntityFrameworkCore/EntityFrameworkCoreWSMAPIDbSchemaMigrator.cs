using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WSMAPI.Data;
using Volo.Abp.DependencyInjection;

namespace WSMAPI.EntityFrameworkCore;

public class EntityFrameworkCoreWSMAPIDbSchemaMigrator
    : IWSMAPIDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreWSMAPIDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the WSMAPIDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<WSMAPIDbContext>()
            .Database
            .MigrateAsync();
    }
}
