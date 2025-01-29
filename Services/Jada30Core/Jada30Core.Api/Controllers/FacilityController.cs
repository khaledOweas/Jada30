using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Facility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class FacilityController : ControllerBase
    {
       
        private readonly IFacilityManagementService _facilityManagementService;

        public FacilityController(IFacilityManagementService facilityManagementService)
        {
            _facilityManagementService = facilityManagementService;
        }

        [HttpGet("GetFacilities")]
        public async Task<BaseResponse<List<FacilityDto>>> GetFacilities()
        {
            return await _facilityManagementService.GetFacilities();
        }

        [HttpGet("GetFacility/{id}")]
        public async Task<BaseResponse<FacilityDto>> GetFacility(int id)
        {
            return await _facilityManagementService.GetFacility(id);
        }

        [HttpPost("CreateFacility")]
        public async Task<BaseResponse<FacilityDto>> CreateFacility(CreateFacilityDto facilityDto)
        {
            return await _facilityManagementService.CreateFacility(facilityDto);
        }

        [HttpPut("UpdateFacility/{id}")]
        public async Task<BaseResponse<FacilityDto>> UpdateFacility(long id, FacilityDto facility)
        {
            return await _facilityManagementService.UpdateFacility(id, facility);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteFacility(int id)
        {
            return await _facilityManagementService.DeleteFacility(id);
        }



    }
}
