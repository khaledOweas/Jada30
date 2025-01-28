using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BranchComponent : EntityBase
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public Branch Branch { get; set; }
        public long ComponentId { get; set; }
        public Lookup Component { get; set; }
    }
}
