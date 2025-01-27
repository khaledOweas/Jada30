using Jada30Core.Application.Interfaces;
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
        public async Task<IActionResult> GetFacilities()
        {
            return Ok(await _facilityManagementService.GetFacilities());
        }

        [HttpGet("GetFacility/{id}")]
        public async Task<IActionResult> GetFacility(int id)
        {
            return Ok(await _facilityManagementService.GetFacility(id));
        }

        [HttpPost("CreateFacility")]
        public async Task<IActionResult> CreateFacility(CreateFacilityDto facilityDto)
        {
            return Ok(await _facilityManagementService.CreateFacility(facilityDto));
        }

        [HttpPut("UpdateFacility/{id}")]
        public async Task<IActionResult> UpdateFacility(long id, FacilityDto facility)
        {
            return Ok(await _facilityManagementService.UpdateFacility(id, facility));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            return Ok(await _facilityManagementService.DeleteFacility(id));
        }



    }
}
