using Domain;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.Event;
using Jada30Core.Common.BaseResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class EventController : ControllerBase
    {
        private readonly IEventManagementService _eventManagementService;

        public EventController(IEventManagementService eventManagementService)
        {
            _eventManagementService = eventManagementService;
        }
        [HttpGet("GetEvents")]
        public async Task<BaseResponse<List<GetEventDto>>> GetEvents()
        {
            return await _eventManagementService.GetEvents();
        }

        [HttpGet("GetEvent/{id}")]
        public async Task<BaseResponse<GetEventDto>> GetEvent(int id)
        {
            return await _eventManagementService.GetEvent(id);
        }

        [HttpPost("CreateEvent")]
        public async Task<BaseResponse<GetEventDto>> CreateEvent([FromForm] CreateEventDto eventModel, [FromForm] IFormFileCollection mediaFiles)
        {
            return await _eventManagementService.AddEvent(eventModel, mediaFiles);
        }

        [HttpPut("UpdateEvent/{id}")]
        public async Task<BaseResponse<GetEventDto>> UpdateEvent(long id, [FromForm] CreateEventDto eventModel, [FromForm] IFormFileCollection mediaFiles)
        {
            return await _eventManagementService.UpdateEvent(id, eventModel, mediaFiles);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteEvent(int id)
        {
            return await _eventManagementService.DeleteEvent(id);
        }

    }
}
