using Jada30Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Facility
{
    public class FacilityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }

        public string? CategoryName { get; set; }
        public string? CategoryNameAr { get; set; }
        public string? TypeName { get; set; }
        public string? TypeNameAr { get; set; }
        public string? DestinationName { get; set; }
        public string? DestinationNameAr { get; set; }
        public string? PricingUnitName { get; set; }
        public string? PricingUnitNameAr { get; set; }

        public string? SubscriptionName { get; set; }
        public string? SubscriptionNameAr { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsTaxIncluded { get; set; }
        public long BasicContract { get; set; }
        public bool IsPublish { get; set; }
    }
}
