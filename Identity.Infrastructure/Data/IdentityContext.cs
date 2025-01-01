using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
