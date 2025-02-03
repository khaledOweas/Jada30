using Jada30Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Facility
{
    public class CreateFacilityDto
    {
        public string Name { get; set; }
        public string NameAr { get; set; }

        public long? CategoryId { get; set; }
        public long? TypeId { get; set; }
        public long? DestinationId { get; set; }
        public long? PricingUnitId { get; set; }
        public long? SubscriptionId { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsTaxIncluded { get; set; }
        public long BasicContract { get; set; }
        public bool IsPublish { get; set; }
    }
}
