﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Lookup
    {
        public long Id { get; set; }

        public required string Name { get; set; }
        public required string NameAr { get; set; }

        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }

        public required string InternalCode { get; set; }

        public string? InternalRef { get; set; }

        public bool IsActive { get; set; }

    }
}
