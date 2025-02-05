using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Perk;
using Jada30Core.Common.Facility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PerkController : ControllerBase
    {

        private readonly IPerkManagementService _perkManagementService;
        public PerkController(IPerkManagementService perkManagementService)
        {
            _perkManagementService = perkManagementService;
        }

        [HttpPost]
        public async Task<BaseResponse<GetPerkDto>> CreatePerk(CreatePerkDto perkDto)
        {
            return await _perkManagementService.AddPerk(perkDto);
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetPerkDto>>> GetPerks()
        {
            return await _perkManagementService.GetPerks();
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<GetPerkDto>> GetPerk(int id)
        {
            return await _perkManagementService.GetPerk(id);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<GetPerkDto>> UpdatePerk(int id, CreatePerkDto perkDto)
        {
            return await _perkManagementService.UpdatePerk(id, perkDto);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeletePerk(int id)
        {
            return await _perkManagementService.DeletePerk(id);
        }

    }
}
