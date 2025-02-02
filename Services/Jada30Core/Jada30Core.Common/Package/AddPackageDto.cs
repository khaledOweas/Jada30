using Jada30Core.Common.PackageFaclilty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Package
{
    public class AddPackageDto
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string DescriptionAr { get; set; }
        public string Description { get; set; }
        public decimal DefaultDiscount { get; set; }
        public string WrittenServices { get; set; } // الخدمات المكتبية
        public int MaxBranchUsers { get; set; } // الحد الأقصى للمستفيدين الفرعيين
        public int MaxMogdiPlatformUsage { get; set; } // الحد الأقصى لاستخدام منصة مجانية
        public ICollection<AddPackageFacilityDto> PackageFacilities { get; set; } = new List<AddPackageFacilityDto>();
    }
}
