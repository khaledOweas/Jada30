using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Branch : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long WebsiteBranchId { get; set; }
        public string WorkingDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long CategoryBranchId { get; set; }
        public ICollection<BranchComponent>? BranchComponents { get; set; } = new List<BranchComponent>();

    }
}
