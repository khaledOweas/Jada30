using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Package : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DefaultDiscount { get; set; }
        public string WrittenServices { get; set; } // الخدمات المكتبية
        public int MaxBranchUsers { get; set; } // الحد الأقصى للمستفيدين الفرعيين
        public int MaxMogdiPlatformUsage { get; set; } // الحد الأقصى لاستخدام منصة مجانية

        public ICollection<PackageFacility> PackageFacilities { get; set; } = new List<PackageFacility>();
    }
}
