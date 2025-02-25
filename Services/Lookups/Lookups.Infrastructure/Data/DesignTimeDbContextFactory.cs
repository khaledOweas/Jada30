using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lookups.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LookupsContext>
    {
        private readonly string _dbConnStr;

        public DesignTimeDbContextFactory()
        {
            _dbConnStr = "Data Source=.;Initial Catalog=Jada30_Identity;User ID=sa;Password=WsmWsm2@22;Integrated Security=False;Trust Server Certificate=True;Encrypt=False";
        }
        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _dbConnStr = configuration.GetConnectionString("Default") ?? "";
        }
        public LookupsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LookupsContext>();

            optionsBuilder.UseSqlServer(_dbConnStr);

            return new LookupsContext(optionsBuilder.Options, null);
        }
    }
}