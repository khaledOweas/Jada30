using Jada30Core.Application.Interfaces;
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
        public async Task<IActionResult> CreateBranch(CreateBranchDto branchDto)
        {
            return Ok(await _branchManagementService.AddBranch(branchDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            return Ok(await _branchManagementService.GetBranches());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            return Ok(await _branchManagementService.GetBranch(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, CreateBranchDto branchDto)
        {
            return Ok(await _branchManagementService.UpdateBranch(id, branchDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            return Ok(await _branchManagementService.DeleteBranch(id));
        }

    }
}
