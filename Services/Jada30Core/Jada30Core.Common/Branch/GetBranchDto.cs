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
        public string AdministrativeRegion { get; set; }
        public string AdministrativeRegionAr { get; set; }

        public string WebsiteBranch { get; set; }
        public string WebsiteBranchAr { get; set; }
        public string WorkingDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CategoryBranch { get; set; }
        public string CategoryBranchAr { get; set; }
        public ICollection<GetBranchComponentDto>? BranchComponents { get; set; }
    }
}
