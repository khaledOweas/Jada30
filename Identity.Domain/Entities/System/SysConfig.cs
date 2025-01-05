using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities.System
{
    public class SysConfig
    {
        public long Id { get; set; }
        public required string Key { get; set; }
        public required string Value { get; set; }
    }
}
