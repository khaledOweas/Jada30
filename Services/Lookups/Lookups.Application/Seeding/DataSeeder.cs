using Infrastructure.Data;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Domain;

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

            var defaultLookups = DefaultData.GetDefaultLookups();
            var saudiGov = DefaultData.GetSaudiArabiaGovernorates();
            var facilityLookups = DefaultData.GetFacilityLookups();

            var allLookupsToSeed = new List<Lookup>();
            allLookupsToSeed.AddRange(defaultLookups);
            allLookupsToSeed.AddRange(saudiGov);
            allLookupsToSeed.AddRange(facilityLookups);

            var existingCodes = await context.Lookups
               .Select(l => l.InternalCode)
               .ToListAsync();

            var newRecords = allLookupsToSeed
               .Where(l => !existingCodes.Contains(l.InternalCode))
               .ToList();

            if (newRecords.Any())
            {
                await context.Lookups.AddRangeAsync(newRecords);
                await context.SaveChangesAsync();
            }
        }

    }
}
