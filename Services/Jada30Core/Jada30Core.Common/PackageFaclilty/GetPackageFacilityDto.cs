using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.PackageFaclilty
{
    public class GetPackageFacilityDto
    {
        public long Id { get; set; }
        public string PackageName { get; set; }
        public string FacilityName { get; set; }
        public string TypeName { get; set; }
        public int quantity { get; set; }
        public decimal PercentageDicount { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxIncluded { get; set; } // السعر شامل الضريبة؟ (Boolean)
    }
}
