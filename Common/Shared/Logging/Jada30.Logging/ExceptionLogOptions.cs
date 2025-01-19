using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jada30.Logging.Filter;

namespace Jada30.Logging
{
    public class ExceptionLogOptions : IConfigureOptions<MvcOptions>
    {
        public void Configure(MvcOptions options)
        {
            options.Filters.Add<ExceptionLogFilter>();
        }
    }
}
