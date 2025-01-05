using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        private readonly string _dbConnStr;

        public DesignTimeDbContextFactory()
        {
            _dbConnStr = "Data Source=.;Initial Catalog=Jada30_Identity; User ID=sa;Password=P@ssw0rd;Integrated Security=False;Trust Server Certificate=True;Encrypt=False";
        }
        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _dbConnStr = configuration.GetConnectionString("Default") ?? "";
        }
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            optionsBuilder.UseSqlServer(_dbConnStr);

            return new IdentityContext(optionsBuilder.Options, null);
        }
    }
}