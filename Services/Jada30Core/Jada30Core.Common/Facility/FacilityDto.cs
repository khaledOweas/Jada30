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
        public FacilityCategory Category { get; set; }
        public FacilityType Type { get; set; }
        public Destination Destination { get; set; }
        public PricingUnit PricingUnit { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsTaxIncluded { get; set; }
        public int BasicContract { get; set; }
        public SubscriptionMechanism Subscription { get; set; }
    }
}
