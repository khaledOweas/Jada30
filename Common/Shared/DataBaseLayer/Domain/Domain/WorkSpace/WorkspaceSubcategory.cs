using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkSpace
{
    public class WorkspaceSubcategory : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public long? WorkspaceCategoryId { get; set; }
        public Lookup? WorkspaceCategory { get; set; } = null!;
        public string UnitOfMeasure { get; set; } = string.Empty;
        public bool WithTax { get; set; }
        public string DefaultContractType { get; set; } = string.Empty;
        public decimal BasicPrice { get; set; }
        public bool IsShared { get; set; }
        public string SubscriptionMechanism { get; set; } = string.Empty;
        public ICollection<WorkspacePriceCategory> PriceCategories { get; set; } = new List<WorkspacePriceCategory>();
    }
}
