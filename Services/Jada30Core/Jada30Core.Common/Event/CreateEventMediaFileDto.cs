using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.Event
{
    public class CreateEventMediaFileDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long EventhId { get; set; }
        public long TypeId { get; set; }
    }
}
