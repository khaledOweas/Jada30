using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Jada30Context : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        private readonly IHttpContextAccessor _context;

        public Jada30Context(DbContextOptions<Jada30Context> options, IHttpContextAccessor context) : base(options)
        {
            _context = context;
        }


        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<SysConfig> SysConfigs { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<BranchComponent> BranchComponents { get; set; }
        public Jada30Context()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SysConfig>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Key).IsRequired();
                entity.Property(e => e.Value).IsRequired();
            });


            modelBuilder.Entity<SysConfig>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Key).IsRequired();
                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Jada30_Identity; User ID=sa;Password=P@ssw0rd;Integrated Security=False;Trust Server Certificate=True;Encrypt=False");
            }
        }

    }
}
