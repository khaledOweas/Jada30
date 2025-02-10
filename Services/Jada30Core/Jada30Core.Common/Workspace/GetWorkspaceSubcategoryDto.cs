using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Workspace
{
    public class GetWorkspaceSubcategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public long WorkspaceCategoryId { get; set; }
        public string WorkspaceCategoryName { get; set; }
        public string WorkspaceCategoryNameAr { get; set; }
        public string UnitOfMeasure { get; set; } = string.Empty;
        public bool WithTax { get; set; }
        public string DefaultContractType { get; set; } = string.Empty;
        public decimal BasicPrice { get; set; }
        public bool IsShared { get; set; }
        public string SubscriptionMechanism { get; set; } = string.Empty;
    }
}
