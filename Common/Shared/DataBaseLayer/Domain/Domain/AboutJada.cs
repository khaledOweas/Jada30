using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AboutJada
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string? ImageFile { get; set; }
        public string? VideoFile { get; set; }
        public string Category { get; set; }
        public bool IsPublish { get; set; }
    }
}
