using Infrastructure.Data;
using Infrastructure;

namespace Lookups.Application.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(Jada30Context context)
        {

            try
            {
                await SeedLookup(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static async Task SeedLookup(Jada30Context context)
        {
            if (!context.Lookups.Any())
            {
                var permissions = DefaultData.GetDefaultLookups();
                await context.Lookups.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }
        }
    }
}
