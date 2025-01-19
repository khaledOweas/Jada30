using Lookups.Infrastructure.Data;

namespace Lookups.Infrastructure.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(LookupsContext context)
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

        public static async Task SeedLookup(LookupsContext context)
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
