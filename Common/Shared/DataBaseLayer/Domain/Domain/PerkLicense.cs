using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PerkLicense : EntityBase
    {
        public long Id { get; set; }
        public long PerkId { get; set; }
        public Perk Perk { get; set; }
        public long LicenseId { get; set; }
        public Lookup License { get; set; }
    }
}
