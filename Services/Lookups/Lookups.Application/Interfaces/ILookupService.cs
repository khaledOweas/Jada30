using Lookups.Common.BaseResponse;
using Lookups.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookups.Application.Interfaces
{
    public interface ILookupService
    {
        Task<BaseResponse<List<GetLookupDto>>> GetAllCategories();
        Task<BaseResponse<List<GetLookupDto>>> GetAllLookups();
        Task<BaseResponse<List<GetLookupDto>>> GetLookupsByRefCode(string refCode);
        Task<BaseResponse<GetLookupDto>> GetLookupByCode(string code);
        Task<BaseResponse<GetLookupDto>> CreateLookup(AddLookupDto lookupDto);
        Task<BaseResponse<GetLookupDto>> UpdateLookup(string code, UpdateLookupDto updateDto);
        Task<BaseResponse<bool>> DeleteLookup(string code);
    }

}
