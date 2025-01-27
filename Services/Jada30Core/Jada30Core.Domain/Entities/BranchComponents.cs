using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Domain.Entities
{
    public class BranchComponents : EntityBase
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public Branch Branch { get; set; }

        public long ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
