using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Workspace
{
    public class GetWorkspacePriceCategoryDto
    {
        public long WorkspaceSubcategoryId { get; set; }
        public string WorkspaceSubcategoryName { get; set; }
        public string WorkspaceSubcategoryNameAr { get; set; }
        public string PriceCategory { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
