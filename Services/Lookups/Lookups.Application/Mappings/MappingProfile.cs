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
            CreateMap<GetLookupDto, Domain.Lookup>().ReverseMap();
            CreateMap<AddLookupDto, Domain.Lookup>().ReverseMap();
            CreateMap<UpdateLookupDto, Domain.Lookup>().ReverseMap();

        }
    }
}
