using Jada30Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Domain.Entities.Facility
{
    public class Facilities : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public FacilityCategory Category { get; set; }
        public FacilityType Type { get; set; }
        public Destination Destination { get; set; }
        public PricingUnit PricingUnit { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsTaxIncluded { get; set; }
        public long BasicContract { get; set; }
        public bool IsPublish{ get; set; }
        public SubscriptionMechanism Subscription { get; set; }

    }
}
