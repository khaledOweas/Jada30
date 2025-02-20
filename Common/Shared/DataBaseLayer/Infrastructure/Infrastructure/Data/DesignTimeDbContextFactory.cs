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
            _dbConnStr = "Data Source=192.168.1.85;Initial Catalog=Tabe3_SQL_DB_10;User ID=SJM_FVDBUser;Password=S@raSJM328311;Integrated Security=False;Trust Server Certificate=True;Encrypt=False";
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