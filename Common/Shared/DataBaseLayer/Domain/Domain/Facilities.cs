using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Facilities : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }

        public long? CategoryId { get; set; }
        public Lookup? Category { get; set; }
        public long? TypeId { get; set; }
        public Lookup? Type { get; set; }
        public long? DestinationId { get; set; }
        public Lookup? Destination { get; set; }
        public long? PricingUnitId { get; set; }
        public Lookup? PricingUnit { get; set; }
        public long? SubscriptionId { get; set; }
        public Lookup? Subscription { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsTaxIncluded { get; set; }
        public long BasicContract { get; set; }
        public bool IsPublish{ get; set; }


    }
}
