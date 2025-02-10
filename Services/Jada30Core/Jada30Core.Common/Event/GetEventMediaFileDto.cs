using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Event
{
    public class GetEventMediaFileDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string EventTitle { get; set; }
        public string EventTitleAr { get; set; }
        public string TypeName { get; set; }
    }
}
