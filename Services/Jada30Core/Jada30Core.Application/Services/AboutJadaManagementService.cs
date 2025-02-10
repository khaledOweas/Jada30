using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.AboutJada;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Jada30Core.Application.Services
{
    internal class AboutJadaManagementService : IAboutJadaManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public AboutJadaManagementService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<BaseResponse<AboutJadaDto>> CreateAboutJada(CreateAboutJadaDto aboutJada)
        {
            IFormCollection request = null;
            var NewAboutJada = _mapper.Map<AboutJada>(aboutJada);
            string imageFile = await _fileService.UploadFile(request.Files[0], aboutJada.Category+$"/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}");
            string videoFile = await _fileService.UploadFile(request.Files[1], aboutJada.Category + $"/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}");
            NewAboutJada.ImageFile = imageFile;
            NewAboutJada.VideoFile = videoFile;
            await _unitOfWork.GetRepository<AboutJada>().InsertAsync(NewAboutJada);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<AboutJadaDto>("AboutJada created successfully.", _mapper.Map<AboutJadaDto>(NewAboutJada));

        }

        public async Task<BaseResponse<bool>> DeleteAboutJada(long id)
        {
            var aboutJada = (await _unitOfWork.GetRepository<AboutJada>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (aboutJada == null)
                return new FailedResponse<bool>("AboutJada not found.");

            _unitOfWork.GetRepository<AboutJada>().Delete(aboutJada);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("AboutJada deleted successfully.", true);

        }

        public async Task<BaseResponse<List<AboutJadaDto>>> GetAboutJada()
        {
            var aboutJada = _unitOfWork.GetRepository<AboutJada>().GetAll(include: x => x.Include(x => x.Category));

            return new SuccessResponse<List<AboutJadaDto>>("AboutJada retrieved successfully.", _mapper.Map<List<AboutJadaDto>>(aboutJada));
        }

        public async Task<BaseResponse<AboutJadaDto>> GetAboutJada(long id)
        {
            var aboutJada = (await _unitOfWork.GetRepository<AboutJada>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.Category))).FirstOrDefault();
            return new SuccessResponse<AboutJadaDto>("AboutJada retrieved successfully.", _mapper.Map<AboutJadaDto>(aboutJada));
        }

        public async Task<BaseResponse<AboutJadaDto>> UpdateAboutJada(long id, AboutJadaDto aboutJada)
        {
            var existingAboutJada = (await _unitOfWork.GetRepository<AboutJada>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (existingAboutJada == null)
                return new FailedResponse<AboutJadaDto>("AboutJada not found.");

            _mapper.Map(aboutJada, existingAboutJada);
            _unitOfWork.GetRepository<AboutJada>().Update(existingAboutJada);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse<AboutJadaDto>("AboutJada updated successfully.", _mapper.Map<AboutJadaDto>(existingAboutJada));
        }
    }
}
