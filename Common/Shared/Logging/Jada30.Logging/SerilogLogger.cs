using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30.Logging
{
    public class SerilogLogger
    {
        public static ILogger Initialize()
        {
            var configuration = new ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("appsettings.LogConfigs.json")
                                   .Build();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();
            //Log.Logger = new LoggerConfiguration()
            // .CreateLogger();
            return Log.Logger;
        }
    }
}
