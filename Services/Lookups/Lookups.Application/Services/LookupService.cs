using AutoMapper;
using Lookups.Application.Interfaces;
using Lookups.Common;
using Lookups.Common.BaseResponse;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lookups.Application.Services
{
    public class LookupService : ILookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LookupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetLookupDto>>> GetAllCategories()
        {
            try
            {
                var lookups = await _unitOfWork.GetRepository<Domain.Lookup>().GetAllAsync(x => x.InternalRef == null);
                var mapped = _mapper.Map<List<GetLookupDto>>(lookups);
                return new SuccessResponse<List<GetLookupDto>>("Categories retrieved successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<List<GetLookupDto>>(ex, "retrieving categories");
            }
        }

        public async Task<BaseResponse<List<GetLookupDto>>> GetAllLookups()
        {
            try
            {
                var lookups = await _unitOfWork.GetRepository<Domain.Lookup>().GetAllAsync();
                var mapped = _mapper.Map<List<GetLookupDto>>(lookups);
                return new SuccessResponse<List<GetLookupDto>>("Lookups retrieved successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<List<GetLookupDto>>(ex, "retrieving lookups");
            }
        }

        public async Task<BaseResponse<List<GetLookupDto>>> GetLookupsByRefCode(string refCode)
        {
            try
            {
                var lookups = await _unitOfWork.GetRepository<Domain.Lookup>().GetAllAsync(x => x.InternalRef == refCode);
                var mapped = _mapper.Map<List<GetLookupDto>>(lookups);
                return new SuccessResponse<List<GetLookupDto>>("Lookups by reference code retrieved successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<List<GetLookupDto>>(ex, "retrieving lookups by reference code");
            }
        }

        public async Task<BaseResponse<GetLookupDto>> GetLookupByCode(string code)
        {
            try
            {
                var lookup = (await _unitOfWork.GetRepository<Domain.Lookup>().GetAllAsync(x => x.InternalCode == code))
                             .FirstOrDefault();
                if (lookup == null)
                {
                    return new FailedResponse<GetLookupDto>($"Lookup with code '{code}' not found.");
                }

                var mapped = _mapper.Map<GetLookupDto>(lookup);
                return new SuccessResponse<GetLookupDto>("Lookup retrieved successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<GetLookupDto>(ex, "retrieving lookup by code");
            }
        }

        public async Task<BaseResponse<GetLookupDto>> CreateLookup(AddLookupDto lookupDto)
        {
            try
            {
                var newLookup = _mapper.Map<Domain.Lookup>(lookupDto);
                await _unitOfWork.GetRepository<Domain.Lookup>().InsertAsync(newLookup);
                await _unitOfWork.SaveChangesAsync();

                var mapped = _mapper.Map<GetLookupDto>(newLookup);
                return new SuccessResponse<GetLookupDto>("Lookup created successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<GetLookupDto>(ex, "creating lookup");
            }
        }

        public async Task<BaseResponse<GetLookupDto>> UpdateLookup(string code, UpdateLookupDto updateDto)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Domain.Lookup>();
                var existingLookup = (await repository.GetAllAsync(x => x.InternalCode == code)).FirstOrDefault();

                if (existingLookup == null)
                {
                    return new FailedResponse<GetLookupDto>($"Lookup with code '{code}' not found.");
                }

                _mapper.Map(updateDto, existingLookup);
                repository.Update(existingLookup);
                await _unitOfWork.SaveChangesAsync();

                var mapped = _mapper.Map<GetLookupDto>(existingLookup);
                return new SuccessResponse<GetLookupDto>("Lookup updated successfully.", mapped);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<GetLookupDto>(ex, "updating lookup");
            }
        }

        public async Task<BaseResponse<bool>> DeleteLookup(string code)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Domain.Lookup>();
                var existingLookup = (await repository.GetAllAsync(x => x.InternalCode == code)).FirstOrDefault();

                if (existingLookup == null)
                {
                    return new FailedResponse<bool>($"Lookup with code '{code}' not found.");
                }

                repository.Delete(existingLookup);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessResponse<bool>("Lookup deleted successfully.", true);
            }
            catch (Exception ex)
            {
                return CreateFailedResponse<bool>(ex, "deleting lookup");
            }
        }

        private static BaseResponse<T> CreateFailedResponse<T>(Exception ex, string action)
        {
            return new FailedResponse<T>($"An error occurred while {action}.",
                new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }
}
