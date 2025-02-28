﻿using Jada30Core.Common.categoryAdministrativeRegion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Common.PriceCategories
{
    public class GetPriceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public bool IsPublish { get; set; }
        public decimal Price { get; set; }

        public ICollection<GetCategoryAdministrativeRegionDto> CategoryAdministrativeRegions { get; set; }
    }
}
