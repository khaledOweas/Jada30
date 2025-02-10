using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryAdministrativeRegion : EntityBase
    {
        public long Id { get; set; }
        public long? AdministrativeRegionId { get; set; }
        public Lookup? AdministrativeRegion { get; set; }

        public long? PricingCategoryId { get; set; }
        public PricingCategories? PricingCategory { get; set; }
    }
}
