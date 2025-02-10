using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class MediaFile : EntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        [JsonIgnore] // Add this attribute
        public Event Event { get; set; }
        public long EventId { get; set; }
        public Lookup Type { get; set; }
        public long TypeId { get; set; }
    }
}
