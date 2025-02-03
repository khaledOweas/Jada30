using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Perk
{
    public class CreatePerkDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxIncluded { get; set; }
        public int AvailableQuantity { get; set; }
        public bool IsForJadah30Customers { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreatePerkLicenseDto>? PerkLicenses { get; set; } = new List<CreatePerkLicenseDto>();
    }
}
