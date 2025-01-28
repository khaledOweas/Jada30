using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Microsoft.EntityFrameworkCore;
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

        public async Task<BaseResponse<GetBranchDto>> AddBranch(CreateBranchDto request)
        {
            var branch = _mapper.Map<Branch>(request);
            await _unitOfWork.GetRepository<Branch>().InsertAsync(branch);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetBranchDto>("Branch created successfully.", _mapper.Map<GetBranchDto>(branch));
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

        public async Task<BaseResponse<List<GetBranchDto>>> GetBranches()
        {
            var branches = _unitOfWork.GetRepository<Branch>().GetAll(include: x => x.Include(x => x.BranchComponents).ThenInclude(x => x.Component));
            return new SuccessResponse<List<GetBranchDto>>("Branches retrieved successfully.", _mapper.Map<List<GetBranchDto>>(branches));
        }

        public async Task<BaseResponse<GetBranchDto>> GetBranch(long id)
        {
            var branch = (await _unitOfWork.GetRepository<Branch>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.BranchComponents).ThenInclude(x => x.Component))).FirstOrDefault();
            return new SuccessResponse<GetBranchDto>("Branch retrieved successfully.", _mapper.Map<GetBranchDto>(branch));
        }

        public async Task<BaseResponse<GetBranchDto>> UpdateBranch(long id, CreateBranchDto request)
        {
            var branch = (await _unitOfWork.GetRepository<Branch>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (branch == null)
                return new FailedResponse<GetBranchDto>("Branch not found.");
            _mapper.Map(request, branch);
            _unitOfWork.GetRepository<Branch>().Update(branch);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResponse<GetBranchDto>("Branch updated successfully.", _mapper.Map<GetBranchDto>(branch));
        }




    }
}
