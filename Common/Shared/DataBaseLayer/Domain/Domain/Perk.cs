using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Perk : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxIncluded { get; set; }
        public int AvailableQuantity { get; set; }
        public bool IsForJadah30Customers { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PerkLicense>? PerkLicenses { get; set; } = new List<PerkLicense>();


    }
}
