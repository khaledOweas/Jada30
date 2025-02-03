using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.SupportingServiceProvider
{
    public class CreateSupportingServiceProviderDto
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public long? SpecializationId { get; set; }
        public long? NationalityId { get; set; }
        public string Address { get; set; }
        public string WebsiteURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsJadah30Restricted { get; set; }
        public bool IsActive { get; set; }
    }
}
