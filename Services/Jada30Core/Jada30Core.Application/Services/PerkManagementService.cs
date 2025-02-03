using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Perk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Services
{
    public class PerkManagementService : IPerkManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PerkManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPerkDto>> AddPerk(CreatePerkDto request)
        {
            var Perk = _mapper.Map<Perk>(request);
            await _unitOfWork.GetRepository<Perk>().InsertAsync(Perk);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetPerkDto>("Perk created successfully.", _mapper.Map<GetPerkDto>(Perk));
        }

        public async Task<BaseResponse<bool>> DeletePerk(long id)
        {
            var Perk = (await _unitOfWork.GetRepository<Perk>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (Perk == null)
                return new FailedResponse<bool>("Perk not found.");
            _unitOfWork.GetRepository<Perk>().Delete(Perk);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("Perk deleted successfully.", true);
        }

        public async Task<BaseResponse<List<GetPerkDto>>> GetPerks()
        {
            var Perks = _unitOfWork.GetRepository<Perk>().GetAll(include: x => x.Include(x => x.PerkLicenses).ThenInclude(x => x.License));
            return new SuccessResponse<List<GetPerkDto>>("Perks retrieved successfully.", _mapper.Map<List<GetPerkDto>>(Perks));
        }

        public async Task<BaseResponse<GetPerkDto>> GetPerk(long id)
        {
            var Perk = (await _unitOfWork.GetRepository<Perk>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.PerkLicenses).ThenInclude(x => x.License))).FirstOrDefault();
            return new SuccessResponse<GetPerkDto>("Perk retrieved successfully.", _mapper.Map<GetPerkDto>(Perk));
        }

        public async Task<BaseResponse<GetPerkDto>> UpdatePerk(long id, CreatePerkDto request)
        {
            var Perk = (await _unitOfWork.GetRepository<Perk>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (Perk == null)
                return new FailedResponse<GetPerkDto>("Perk not found.");
            _mapper.Map(request, Perk);
            _unitOfWork.GetRepository<Perk>().Update(Perk);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetPerkDto>("Perk updated successfully.", _mapper.Map<GetPerkDto>(Perk));
        }




    }
}
