using AutoMapper;
using Lookups.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookups.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetLookupDto, Domain.Entities.Lookup>().ReverseMap();
            CreateMap<AddLookupDto, Domain.Entities.Lookup>().ReverseMap();
            CreateMap<UpdateLookupDto, Domain.Entities.Lookup>().ReverseMap();

        }
    }
}
