using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.PackageFaclilty
{
    public class AddPackageFacilityDto
    {
        public long PackageId { get; set; }
        public long FacilityId { get; set; }
        public long TypeId { get; set; }

        public int quantity { get; set; }
        public decimal PercentageDicount { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxIncluded { get; set; } // السعر شامل الضريبة؟ (Boolean)
    }
}
