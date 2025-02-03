using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.SupportingServiceProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class SupportingServiceProviderController : ControllerBase
    {
       
        private readonly ISupportingServiceProviderManagementService _supportingServiceProviderManagementService;

        public SupportingServiceProviderController(ISupportingServiceProviderManagementService supportingServiceProviderManagementService)
        {
            _supportingServiceProviderManagementService = supportingServiceProviderManagementService;
        }

        [HttpGet("GetFacilities")]
        public async Task<BaseResponse<List<SupportingServiceProviderDto>>> GetSupportingServiceProviders()
        {
            return await _supportingServiceProviderManagementService.GetSupportingServiceProviders();
        }

        [HttpGet("GetSupportingServiceProvider/{id}")]
        public async Task<BaseResponse<SupportingServiceProviderDto>> GetSupportingServiceProvider(int id)
        {
            return await _supportingServiceProviderManagementService.GetSupportingServiceProvider(id);
        }

        [HttpPost("CreateSupportingServiceProvider")]
        public async Task<BaseResponse<SupportingServiceProviderDto>> CreateSupportingServiceProvider(CreateSupportingServiceProviderDto supportingServiceProviderDto)
        {
            return await _supportingServiceProviderManagementService.CreateSupportingServiceProvider(supportingServiceProviderDto);
        }

        [HttpPut("UpdateSupportingServiceProvider/{id}")]
        public async Task<BaseResponse<SupportingServiceProviderDto>> UpdateSupportingServiceProvider(long id, CreateSupportingServiceProviderDto supportingServiceProvider)
        {
            return await _supportingServiceProviderManagementService.UpdateSupportingServiceProvider(id, supportingServiceProvider);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteSupportingServiceProvider(int id)
        {
            return await _supportingServiceProviderManagementService.DeleteSupportingServiceProvider(id);
        }



    }
}
