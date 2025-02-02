using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Branch
{
    public class GetBranchDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public long AdministrativeRegionId { get; set; }

        public long WebsiteBranchId { get; set; }
        public string WorkingDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long CategoryBranchId { get; set; }
        public ICollection<GetBranchComponentDto>? BranchComponents { get; set; }
    }
}
