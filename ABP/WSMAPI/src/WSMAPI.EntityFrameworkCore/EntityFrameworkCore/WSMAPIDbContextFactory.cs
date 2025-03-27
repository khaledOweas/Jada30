using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WSMAPI.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class WSMAPIDbContextFactory : IDesignTimeDbContextFactory<WSMAPIDbContext>
{
    public WSMAPIDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        WSMAPIEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<WSMAPIDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new WSMAPIDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WSMAPI.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
