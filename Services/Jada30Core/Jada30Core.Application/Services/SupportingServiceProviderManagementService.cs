using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.SupportingServiceProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class SupportingServiceProviderManagementService : ISupportingServiceProviderManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupportingServiceProviderManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<SupportingServiceProviderDto>> CreateSupportingServiceProvider(CreateSupportingServiceProviderDto supportingServiceProvider)
        {
            var NewSupportingServiceProvider = _mapper.Map<SupportingServiceProvider>(supportingServiceProvider);
            await  _unitOfWork.GetRepository<SupportingServiceProvider>().InsertAsync(NewSupportingServiceProvider);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<SupportingServiceProviderDto>("SupportingServiceProvider created successfully.", _mapper.Map<SupportingServiceProviderDto>(NewSupportingServiceProvider));

        }

        public async Task<BaseResponse<bool>> DeleteSupportingServiceProvider(long id)
        {
           var supportingServiceProvider = (await _unitOfWork.GetRepository<SupportingServiceProvider>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (supportingServiceProvider == null)
                return new FailedResponse<bool>("SupportingServiceProvider not found.");

            _unitOfWork.GetRepository<SupportingServiceProvider>().Delete(supportingServiceProvider);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("SupportingServiceProvider deleted successfully.", true);

        }

        public async Task<BaseResponse<List<SupportingServiceProviderDto>>> GetSupportingServiceProviders()
        {
            var SupportingServiceProvider = _unitOfWork.GetRepository<SupportingServiceProvider>().GetAll(include: x => x.Include(x => x.Nationality).Include(x => x.Nationality));

            return new SuccessResponse<List<SupportingServiceProviderDto>>("SupportingServiceProvider retrieved successfully.", _mapper.Map<List<SupportingServiceProviderDto>>(SupportingServiceProvider));
        }

        public async Task<BaseResponse<SupportingServiceProviderDto>> GetSupportingServiceProvider(long id)
        {
           var SupportingServiceProvider = (await _unitOfWork.GetRepository<SupportingServiceProvider>().GetAllAsync(x => x.Id == id,include: x => x.Include(x => x.Nationality).Include(x => x.Nationality))).FirstOrDefault();
            return new SuccessResponse<SupportingServiceProviderDto>("SupportingServiceProvider retrieved successfully.", _mapper.Map<SupportingServiceProviderDto>(SupportingServiceProvider));
        }

        public async Task<BaseResponse<SupportingServiceProviderDto>> UpdateSupportingServiceProvider(long id, CreateSupportingServiceProviderDto supportingServiceProvider)
        {
           var existingSupportingServiceProvider = (await _unitOfWork.GetRepository<SupportingServiceProvider>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (existingSupportingServiceProvider == null)
                return new FailedResponse<SupportingServiceProviderDto>("SupportingServiceProvider not found.");

            _mapper.Map(supportingServiceProvider, existingSupportingServiceProvider);
            _unitOfWork.GetRepository<SupportingServiceProvider>().Update(existingSupportingServiceProvider);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse<SupportingServiceProviderDto>("SupportingServiceProvider updated successfully.", _mapper.Map<SupportingServiceProviderDto>(existingSupportingServiceProvider));
        }

    }
}
