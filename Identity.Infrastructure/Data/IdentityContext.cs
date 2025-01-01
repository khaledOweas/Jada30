using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Data
{
    public class IdentityContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _context;

        public IdentityContext(DbContextOptions<IdentityContext> options, IHttpContextAccessor context) : base(options)
        {
            _context = context;
        }
        public IdentityContext()
        {

        }
    }
}
