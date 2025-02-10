using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkSpace
{
    public class WorkspacePriceCategory : EntityBase
    {
        public long Id { get; set; }
        public long? WorkspaceSubcategoryId { get; set; }
        public WorkspaceSubcategory? WorkspaceSubcategory { get; set; } = null!;
        public string PriceCategory { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
