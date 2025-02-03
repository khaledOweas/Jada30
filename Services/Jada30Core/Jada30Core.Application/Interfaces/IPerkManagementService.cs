using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Perk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IPerkManagementService
    {

        Task<BaseResponse<GetPerkDto>> AddPerk(CreatePerkDto request);
        Task<BaseResponse<GetPerkDto>> UpdatePerk(long id, CreatePerkDto request);
        Task<BaseResponse<bool>> DeletePerk(long id);
        Task<BaseResponse<GetPerkDto>> GetPerk(long id);
        Task<BaseResponse<List<GetPerkDto>>> GetPerks();
    }
}
