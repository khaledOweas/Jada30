using AutoMapper;
using Domain;
using Framework;
using Infrastructure.Migrations;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackExchange.Redis.Role;

namespace Jada30Core.Application.Services
{
    public class EventManagementService : IEventManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        public EventManagementService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }
        private long GetMediaTypeId(string contentType)
        {
            // Implement logic to determine the media type ID based on the content type
            // Example: 1 for image, 2 for video, etc.
            if (contentType.StartsWith("image"))
                return 1;
            if (contentType.StartsWith("video"))
                return 2;
            return 0; // Unknown type
        }
        public async Task<BaseResponse<GetEventDto>> AddEvent(CreateEventDto eventModel, IFormFileCollection mediaFiles)
        {
            var eModel = _mapper.Map<Event>(eventModel);
            await _unitOfWork.GetRepository<Event>().InsertAsync(eModel);

            // Save media files
            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                foreach (var file in mediaFiles)
                {
                    var filePath = await _fileStorageService.SaveFileAsync(file);
                    var mediaFile = new MediaFile
                    {
                        Name = file.Name,
                        Path = filePath,
                        EventId = 1,
                        TypeId = GetMediaTypeId(file.ContentType) , // Implement this method to determine the type
                    };
                    await _unitOfWork.GetRepository<MediaFile>().InsertAsync(mediaFile);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetEventDto>("Event created successfully.", _mapper.Map<GetEventDto>(eModel));
        }

        public async Task<BaseResponse<bool>> DeleteEvent(long id)
        {
            var events = (await _unitOfWork.GetRepository<Event>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (events == null)
                return new FailedResponse<bool>("Event not found.");
            _unitOfWork.GetRepository<Event>().Delete(events);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("Event deleted successfully.", true);
        }

        public async Task<BaseResponse<GetEventDto>> GetEvent(long id)
        {
            //var events = (await _unitOfWork.GetRepository<Event>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.MediaFiles).ThenInclude(x => x.Type)));
            var eventEntity = await _unitOfWork.GetRepository<Event>()
                .GetFirstOrDefaultAsync(
                    predicate: x => x.Id == id,
                    include: x => x.Include(x => x.MediaFiles).ThenInclude(x => x.Type)
                );
            var eventDto = _mapper.Map<GetEventDto>(eventEntity);
            return new SuccessResponse<GetEventDto>("Event retrieved successfully.", eventDto);
        }

        public async Task<BaseResponse<List<GetEventDto>>> GetEvents()
        {
            var events = _unitOfWork.GetRepository<Event>().GetAll(include: x => x.Include(x => x.MediaFiles).ThenInclude(x => x.Type));
            var eventDtos = _mapper.Map<List<GetEventDto>>(events);
            return new SuccessResponse<List<GetEventDto>>("Events retrieved successfully.", eventDtos);
        }

        public async Task<BaseResponse<GetEventDto>> UpdateEvent(long id, CreateEventDto eventModel, IFormFileCollection mediaFiles)
        {
            var events = (await _unitOfWork.GetRepository<Event>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (events == null)
                return new FailedResponse<GetEventDto>("Event not found.");
            _mapper.Map(eventModel, events);
            _unitOfWork.GetRepository<Event>().Update(events);

            //// Save media files
            //if (mediaFiles != null && mediaFiles.Count > 0)
            //{
            //    foreach (var file in mediaFiles)
            //    {
            //        var filePath = await _fileStorageService.SaveFileAsync(file);
            //        var mediaFile = new MediaFile
            //        {
            //            Name = file.Name,
            //            Path = filePath,
            //            EventId = id,
            //            TypeId = events.Type.Id, 
            //        };
            //        await _unitOfWork.GetRepository<MediaFile>().InsertAsync(mediaFile);
            //    }
            //}
            // Update media files (optional: delete old files and add new ones)
            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                var existingFiles = await _unitOfWork.GetRepository<MediaFile>().GetAllAsync(m => m.EventId == id);
                foreach (var file in existingFiles)
                {
                    _fileStorageService.DeleteFile(file.Path);
                    _unitOfWork.GetRepository<MediaFile>().Delete(file);
                }

                foreach (var file in mediaFiles)
                {
                    var filePath = await _fileStorageService.SaveFileAsync(file);
                    var mediaFile = new MediaFile
                    {
                        Name = file.FileName,
                        Path = filePath,
                        EventId = id,
                        TypeId = GetMediaTypeId(file.ContentType)
                    };
                    await _unitOfWork.GetRepository<MediaFile>().InsertAsync(mediaFile);
                }
            }


            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetEventDto>("Event updated successfully.", _mapper.Map<GetEventDto>(events));
        }
    }
}
