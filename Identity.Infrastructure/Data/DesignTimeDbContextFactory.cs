using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>(); 

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Jada30_Identity; User ID=sa;Password=P@ssw0rd;Integrated Security=False;Trust Server Certificate=True;Encrypt=False");

            return new IdentityContext(optionsBuilder.Options, null);
        }
    }
}