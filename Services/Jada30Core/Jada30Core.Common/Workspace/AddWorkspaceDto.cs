using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Workspace
{
    public class AddWorkspaceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public long WorkspaceCategoryId { get; set; }
        public long WorkspaceSubcategoryId { get; set; }
        public int Floor { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsSubcategoryShared { get; set; }
        public string InternalOrView { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
    }
}
