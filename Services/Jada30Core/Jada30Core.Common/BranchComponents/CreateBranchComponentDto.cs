using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.BranchComponents
{
    public class CreateBranchComponentDto
    {
        public long BranchId { get; set; }

        public long ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
