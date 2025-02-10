using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Event;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IEventManagementService
    {
        Task<BaseResponse<GetEventDto>> AddEvent(CreateEventDto eventModel, IFormFileCollection mediaFiles);
        Task<BaseResponse<GetEventDto>> UpdateEvent(long id, CreateEventDto eventModel, IFormFileCollection mediaFiles);
        Task<BaseResponse<bool>> DeleteEvent(long id);
        Task<BaseResponse<GetEventDto>> GetEvent(long id);
        Task<BaseResponse<List<GetEventDto>>> GetEvents();
    }
}
