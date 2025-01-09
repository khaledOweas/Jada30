using Lookups.Domain.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Lookups.Infrastructure.Data;
public class LookupsContext : DbContext
{
    private readonly IHttpContextAccessor _context;

    public LookupsContext(DbContextOptions<LookupsContext> options, IHttpContextAccessor context) : base(options)
    {
        _context = context;
    }
    public DbSet<Lookup> Lookups { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

