using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkSpace
{
    public class Workspace : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DescriptionAr { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public long? WorkspaceCategoryId { get; set; }
        public Lookup? WorkspaceCategory { get; set; } = null!;
        public long? WorkspaceSubcategoryId { get; set; }
        public WorkspaceSubcategory? WorkspaceSubcategory { get; set; } = null!;
        public int Floor { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsSubcategoryShared { get; set; }
        public string InternalOrView { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
    }
}
