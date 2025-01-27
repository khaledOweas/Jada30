
using Jada30Core.Domain.Entities.Facility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jada30Core.Infrastructure.Data
{
    public class Jada30CoreContext : DbContext
    {
        private readonly IHttpContextAccessor _context;

        public Jada30CoreContext(DbContextOptions<Jada30CoreContext> options, IHttpContextAccessor context) : base(options)
        {
            _context = context;
        }

       
        public DbSet<Facilities> Facilities { get; set; }
        public Jada30CoreContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=192.168.1.85;Initial Catalog=Tabe3_SQL_DB_1;User ID=SJM_FVDBUser;Password=S@raSJM328311;Integrated Security=False;Trust Server Certificate=True;Encrypt=False");
            }
        }

    }

}
