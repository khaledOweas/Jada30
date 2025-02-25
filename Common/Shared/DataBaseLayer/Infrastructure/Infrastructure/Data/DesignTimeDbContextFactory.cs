using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Jada30Context>
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
        public Jada30Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Jada30Context>();

            optionsBuilder.UseSqlServer(_dbConnStr);

            return new Jada30Context(optionsBuilder.Options, null);
        }
    }
}