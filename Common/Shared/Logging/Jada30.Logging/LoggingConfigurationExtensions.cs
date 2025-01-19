using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace Jada30.Logging
{
    public static class LoggingConfigurationExtensions
    {
        public static WebApplicationBuilder AddLoggingConfiguration(this WebApplicationBuilder builder)
        {
            //builder.Services.AddSerilog(); // <-- add this
            //Log.Logger = SerilogLogger.Initialize();
            //builder.Logging.ClearProviders();
            //builder.Logging.AddSerilog(Log.Logger);


            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.LogConfigs.json")
                                .Build();

            Log.Logger = new LoggerConfiguration()
               //.MinimumLevel.Information()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            //        Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Information()
            //.WriteTo.Console()
            //.WriteTo.File("log.txt",
            //    rollingInterval: RollingInterval.Day,
            //    rollOnFileSizeLimit: true)
            //.CreateLogger();

            builder.Host.UseSerilog(Log.Logger);

            return builder;
        }

        public static void ConfigureLogging()
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.LogConfigs.json")
            //    .Build();

            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.LogConfigs.json", optional: false, reloadOnChange: true)
           .Build();


            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        public static void AddExceptionLogging(this IServiceCollection services)
        {
            services.ConfigureOptions<ExceptionLogOptions>();
        }
    }
}
