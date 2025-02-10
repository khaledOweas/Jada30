using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.PriceCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Services
{
    public class PriceCategoriesManagementService : IPriceCategoriesManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PriceCategoriesManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPriceCategory>> AddPriceCategory(AddPriceCategory request)
        {
            var priceCategory = _mapper.Map<PricingCategories>(request);
            priceCategory.CategoryAdministrativeRegions = request.CategoryAdministrativeRegionIds.Select(x => new CategoryAdministrativeRegion { AdministrativeRegionId = x }).ToList();
            await _unitOfWork.GetRepository<PricingCategories>().InsertAsync(priceCategory);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetPriceCategory>("Price Category created successfully.", _mapper.Map<GetPriceCategory>(priceCategory));
        }

        public async Task<BaseResponse<GetPriceCategory>> UpdatePriceCategory(long id, AddPriceCategory request)
        {
            var priceCategory = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => x.Id == id && !x.IsDeleted,include: x => x.Include(x => x.CategoryAdministrativeRegions).ThenInclude(x => x.AdministrativeRegion))).FirstOrDefault();
            if (priceCategory == null)
                return new FailedResponse<GetPriceCategory>("Price Category not found.");
            _mapper.Map(request, priceCategory);
            _unitOfWork.GetRepository<PricingCategories>().Update(priceCategory);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetPriceCategory>("Price Category updated successfully.", _mapper.Map<GetPriceCategory>(priceCategory));
        }

        public async Task<BaseResponse<bool>> DeletePriceCategory(long id)
        {
            var priceCategory = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (priceCategory == null)
                return new FailedResponse<bool>("Price Category not found.");
            priceCategory.IsDeleted = true;
            _unitOfWork.GetRepository<PricingCategories>().Update(priceCategory);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("Price Category deleted successfully.", true);
        }

        public async Task<BaseResponse<GetPriceCategory>> GetPriceCategory(long id)
        {
            var priceCategory = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => x.Id == id && !x.IsDeleted, include: x => x.Include(x => x.CategoryAdministrativeRegions).ThenInclude(x => x.AdministrativeRegion))).FirstOrDefault();
            if (priceCategory == null)
                return new FailedResponse<GetPriceCategory>("Price Category not found.");
            return new SuccessResponse<GetPriceCategory>("Price Category retrieved successfully.", _mapper.Map<GetPriceCategory>(priceCategory));
        }

        public async Task<BaseResponse<List<GetPriceCategory>>> GetPriceCategories()
        {
            var priceCategories = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => !x.IsDeleted, include: x => x.Include(x => x.CategoryAdministrativeRegions).ThenInclude(x => x.AdministrativeRegion))).ToList();
            return new SuccessResponse<List<GetPriceCategory>>("Price Categories retrieved successfully.", _mapper.Map<List<GetPriceCategory>>(priceCategories));
        }

        public async Task<BaseResponse<List<GetPriceCategory>>> GetPriceCategories(string name)
        {
            var priceCategories = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => x.Name.Contains(name) && !x.IsDeleted)).ToList();
            return new SuccessResponse<List<GetPriceCategory>>("Price Categories retrieved successfully.", _mapper.Map<List<GetPriceCategory>>(priceCategories));
        }

        public async Task<BaseResponse<string>> ToggelPublish(long id)
        {
            var priceCategory = (await _unitOfWork.GetRepository<PricingCategories>().GetAllAsync(x => x.Id == id && !x.IsDeleted, include: x => x.Include(x => x.CategoryAdministrativeRegions).ThenInclude(x => x.AdministrativeRegion))).FirstOrDefault();
            if (priceCategory == null)
                return new FailedResponse<string>("Price Category not found.");
            priceCategory.IsPublish = !priceCategory.IsPublish;
            _unitOfWork.GetRepository<PricingCategories>().Update(priceCategory);
            await _unitOfWork.SaveChangesAsync();
            
            return new SuccessResponse<string>("Price Category publish status updated successfully.",null);
        }

    }
}
