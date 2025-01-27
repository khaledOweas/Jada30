using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.BranchComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Services
{
    public class BranchManagementService : IBranchManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BranchManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetBranchComponentDto>> AddBranch(CreateBranchDto request)
        {
            var branch = _mapper.Map<Branch>(request);
            await _unitOfWork.GetRepository<Branch>().InsertAsync(branch);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetBranchComponentDto>("Branch created successfully.", _mapper.Map<GetBranchComponentDto>(branch));
        }

        public async Task<BaseResponse<bool>> DeleteBranch(long id)
        {
            var branch = (await _unitOfWork.GetRepository<Branch>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (branch == null)
                return new FailedResponse<bool>("Branch not found.");
            _unitOfWork.GetRepository<Branch>().Delete(branch);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<bool>("Branch deleted successfully.", true);
        }

        public async Task<BaseResponse<List<GetBranchComponentDto>>> GetBranches()
        {
            var branches = _unitOfWork.GetRepository<Branch>().GetAll();
            return new SuccessResponse<List<GetBranchComponentDto>>("Branches retrieved successfully.", _mapper.Map<List<GetBranchComponentDto>>(branches));
        }

        public async Task<BaseResponse<GetBranchComponentDto>> GetBranch(long id)
        {
            var branch = (await _unitOfWork.GetRepository<Branch>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            return new SuccessResponse<GetBranchComponentDto>("Branch retrieved successfully.", _mapper.Map<GetBranchComponentDto>(branch));
        }

        public async Task<BaseResponse<GetBranchComponentDto>> UpdateBranch(long id, CreateBranchDto request)
        {
            var branch = (await _unitOfWork.GetRepository<Branch>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (branch == null)
                return new FailedResponse<GetBranchComponentDto>("Branch not found.");
            _mapper.Map(request, branch);
            _unitOfWork.GetRepository<Branch>().Update(branch);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetBranchComponentDto>("Branch updated successfully.", _mapper.Map<GetBranchComponentDto>(branch));
        }




    }
}
