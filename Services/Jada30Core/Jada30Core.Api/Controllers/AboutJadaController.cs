using Domain;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.AboutJada;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Facility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AboutJadaController : Controller
    {
        private readonly IAboutJadaManagementService _aboutJadaManagementService;

        public AboutJadaController(IAboutJadaManagementService aboutJadaManagementService)
        {
            _aboutJadaManagementService = aboutJadaManagementService;
        }

        [HttpGet("GetAboutJada")]
        public async Task<BaseResponse<List<AboutJadaDto>>> GetAboutJada()
        {
            return await _aboutJadaManagementService.GetAboutJada();
        }

        [HttpGet("GetAboutJada/{id}")]
        public async Task<BaseResponse<AboutJadaDto>> GetAboutJada(int id)
        {
            return await _aboutJadaManagementService.GetAboutJada(id);
        }

        [HttpPost("CreateAboutJada")]
        public async Task<BaseResponse<AboutJadaDto>> CreateAboutJada(CreateAboutJadaDto aboutJadaDto)
        {
            return await _aboutJadaManagementService.CreateAboutJada(aboutJadaDto);
        }

        [HttpPut("UpdateAboutJada/{id}")]
        public async Task<BaseResponse<AboutJadaDto>> UpdateAboutJada(long id, AboutJadaDto aboutJada)
        {
            return await _aboutJadaManagementService.UpdateAboutJada(id, aboutJada);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteAboutJada(int id)
        {
            return await _aboutJadaManagementService.DeleteAboutJada(id);
        }

    }
}
