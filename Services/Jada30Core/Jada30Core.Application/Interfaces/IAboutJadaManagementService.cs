using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.AboutJada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Jada30Core.Application.Interfaces
{
    public interface IAboutJadaManagementService
    {
        Task<BaseResponse<AboutJadaDto>> CreateAboutJada(CreateAboutJadaDto aboutJada);
        Task<BaseResponse<List<AboutJadaDto>>> GetAboutJada();
        Task<BaseResponse<AboutJadaDto>> GetAboutJada(long id);
        Task<BaseResponse<AboutJadaDto>> UpdateAboutJada(long id, AboutJadaDto aboutJada);
        Task<BaseResponse<bool>> DeleteAboutJada(long id);
    }
}
