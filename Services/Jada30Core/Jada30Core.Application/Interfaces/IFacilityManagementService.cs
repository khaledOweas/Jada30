using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IFacilityManagementService
    {
        Task<BaseResponse<FacilityDto>> CreateFacility(CreateFacilityDto facility);
        Task<BaseResponse<List<FacilityDto>>> GetFacilities();
        Task<BaseResponse<FacilityDto>> GetFacility(long id);
        Task<BaseResponse<FacilityDto>> UpdateFacility(long id, FacilityDto facility);
        Task<BaseResponse<bool>> DeleteFacility(long id);
    }
}
