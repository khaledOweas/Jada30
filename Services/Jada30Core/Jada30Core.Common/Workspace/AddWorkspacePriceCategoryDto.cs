using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Workspace
{
    public class AddWorkspacePriceCategoryDto
    {
        public long WorkspaceSubcategoryId { get; set; }
        public string PriceCategory { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
