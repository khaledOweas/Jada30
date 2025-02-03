using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PackageFacility : EntityBase
    {
        public long Id { get; set; }
        public long PackageId { get; set; }
        public Package Package { get; set; }
        public long FacilityId { get; set; }
        public Facilities Facility { get; set; }
        public long TypeId { get; set; }
        public Lookup Type { get; set; }

        public int quantity { get; set; }
        public decimal PercentageDicount { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxIncluded { get; set; } // السعر شامل الضريبة؟ (Boolean)

    }
}
