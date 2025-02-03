using Jada30Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.SupportingServiceProvider
{
    public class SupportingServiceProviderDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string SpecializationName { get; set; }
        public string NationalityName { get; set; }
        public string Address { get; set; }
        public string WebsiteURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsJadah30Restricted { get; set; }
        public bool IsActive { get; set; }
    }
}
