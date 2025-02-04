using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.categoryAdministrativeRegion
{
    public class GetCategoryAdministrativeRegionDto
    {
        public long Id { get; set; }
        public long? AdministrativeRegionId { get; set; }
        public string? AdministrativeRegionName { get; set; }
        public string? AdministrativeRegionNameAr { get; set; }

        public long? PricingCategoryId { get; set; }
        public string? PricingCategoryName { get; set; }
        public string? PricingCategoryNameAr { get; set; }
    }
}
