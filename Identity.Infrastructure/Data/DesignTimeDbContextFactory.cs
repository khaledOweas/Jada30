using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            // Use the connection string configured for your Azure SQL Database
            optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=; User ID=;Password=;Integrated Security=False;Trust Server Certificate=True;Encrypt=False");

            return new IdentityContext(optionsBuilder.Options, null);
        }
    }
}
