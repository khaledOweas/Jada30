﻿using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Facility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class FacilityManagementService : IFacilityManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FacilityManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<FacilityDto>> CreateFacility(CreateFacilityDto facility)
        {
            var NewFaciltiy = _mapper.Map<Facilities>(facility);
            await  _unitOfWork.GetRepository<Facilities>().InsertAsync(NewFaciltiy);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<FacilityDto>("Facility created successfully.", _mapper.Map<FacilityDto>(NewFaciltiy));

        }

        public async Task<BaseResponse<bool>> DeleteFacility(long id)
        {
           var facility = (await _unitOfWork.GetRepository<Facilities>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (facility == null)
                return new FailedResponse<bool>("Facility not found.");

            _unitOfWork.GetRepository<Facilities>().Delete(facility);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("Facility deleted successfully.", true);

        }

        public async Task<BaseResponse<List<FacilityDto>>> GetFacilities()
        {
            var facilities = _unitOfWork.GetRepository<Facilities>().GetAll(include: x => x.Include(x => x.Category).Include(x => x.Type).Include(x => x.Subscription).Include(x => x.PricingUnit).Include(x => x.Destination));

            return new SuccessResponse<List<FacilityDto>>("Facilities retrieved successfully.", _mapper.Map<List<FacilityDto>>(facilities));
        }

        public async Task<BaseResponse<FacilityDto>> GetFacility(long id)
        {
           var facility = (await _unitOfWork.GetRepository<Facilities>().GetAllAsync(x => x.Id == id,include: x => x.Include(x => x.Category).Include(x => x.Type).Include(x => x.Subscription).Include(x => x.PricingUnit).Include(x => x.Destination))).FirstOrDefault();
            return new SuccessResponse<FacilityDto>("Facility retrieved successfully.", _mapper.Map<FacilityDto>(facility));
        }

        public async Task<BaseResponse<FacilityDto>> UpdateFacility(long id, FacilityDto facility)
        {
           var existingFacility = (await _unitOfWork.GetRepository<Facilities>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (existingFacility == null)
                return new FailedResponse<FacilityDto>("Facility not found.");

            _mapper.Map(facility, existingFacility);
            _unitOfWork.GetRepository<Facilities>().Update(existingFacility);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse<FacilityDto>("Facility updated successfully.", _mapper.Map<FacilityDto>(existingFacility));
        }
    }
}
