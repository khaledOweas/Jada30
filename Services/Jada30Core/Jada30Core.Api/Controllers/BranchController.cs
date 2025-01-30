using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class BranchController : ControllerBase
    {
       
        private readonly IBranchManagementService _branchManagementService;
        public BranchController(IBranchManagementService branchManagementService)
        {
            _branchManagementService = branchManagementService;
        }

        [HttpPost]
        public async Task<BaseResponse<GetBranchDto>> CreateBranch(CreateBranchDto branchDto)
        {
            return await _branchManagementService.AddBranch(branchDto);
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetBranchDto>>> GetBranches()
        {
            return await _branchManagementService.GetBranches();
        }

        [HttpGet("{id}")]
      
        public async Task<BaseResponse<GetBranchDto>> GetBranch(int id)
        {
            return await _branchManagementService.GetBranch(id);
        }

        [HttpPut("{id}")]
     
        public async Task<BaseResponse<GetBranchDto>> UpdateBranch(int id, CreateBranchDto branchDto)
        {
            return await _branchManagementService.UpdateBranch(id, branchDto);
        }

        [HttpDelete("{id}")]
     
        public async Task<BaseResponse<bool>> DeleteBranch(int id)
        {
            return await _branchManagementService.DeleteBranch(id);
        }

    }
}
