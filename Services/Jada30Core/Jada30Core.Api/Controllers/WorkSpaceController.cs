using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Workspace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class WorkSpaceController : ControllerBase
    {
       
        private readonly IWorkspaceManagementService  _workspaceManagementService;
        public WorkSpaceController(IWorkspaceManagementService workspaceManagementService)
        {
            _workspaceManagementService = workspaceManagementService;
        }

        
        [HttpGet]
        public async Task<BaseResponse<List<GetWorkspaceDto>>> GetWorkSpaces()
        {
            return await _workspaceManagementService.GetAllWorkspace();
        }

        [HttpGet("GetWorkSpace/{id}")]
        public async Task<BaseResponse<GetWorkspaceDto>> GetWorkSpace(long id)
        {
            return await _workspaceManagementService.GetWorkspace(id);
        }

        [HttpPost("CreateWorkSpace")]
        public async Task<BaseResponse<string>> CreateWorkSpace(AddWorkspaceDto workspaceDto)
        {
            return await _workspaceManagementService.AddWorkspace(workspaceDto);
        }

        [HttpDelete("DeleteWorkSpace/{id}")]
        public async Task<BaseResponse<string>> DeleteWorkSpace(long id)
        {
            return await _workspaceManagementService.DeleteWorkspace(id);
        }

        [HttpPut("UpdateWorkSpace/{id}")]
        public async Task<BaseResponse<string>> UpdateWorkSpace(long id, AddWorkspaceDto workspaceDto)
        {
            return await _workspaceManagementService.UpdateWorkspace(id, workspaceDto);
        }

        [HttpPost("CreateWorkSpaceSubCategory")]
        public async Task<BaseResponse<string>> CreateWorkSpaceSubCategory(AddWorkspaceSubcategoryDto workSpaceSubCategoryDto)
        {
            return await _workspaceManagementService.AddWorkspaceSubCategory(workSpaceSubCategoryDto);
        }

        [HttpPut("UpdateWorkSpaceSubCategory/{id}")]
        public async Task<BaseResponse<string>> UpdateWorkSpaceSubCategory(long id, AddWorkspaceSubcategoryDto workSpaceSubCategoryDto)
        {
            return await _workspaceManagementService.UpdateWorkspaceSubCategory(id, workSpaceSubCategoryDto);
        }

        [HttpDelete("DeleteWorkSpaceSubCategory/{id}")]
        public async Task<BaseResponse<string>> DeleteWorkSpaceSubCategory(long id)
        {
            return await _workspaceManagementService.DeleteWorkspaceSubCategory(id);
        }

        [HttpGet("GetWorkSpaceSubCategory/{id}")]
        public async Task<BaseResponse<GetWorkspaceSubcategoryDto>> GetWorkSpaceSubCategory(long id)
        {
            return await _workspaceManagementService.GetWorkspaceSubCategory(id);
        }

        [HttpGet("GetWorkSpaceSubCategories")]
        public async Task<BaseResponse<List<GetWorkspaceSubcategoryDto>>> GetWorkSpaceSubCategories()
        {
            return await _workspaceManagementService.GetAllWorkspaceSubCategories();
        }

        [HttpPost("CreateWorkSpacePriceCategory")]
        public async Task<BaseResponse<string>> CreateWorkSpacePriceCategory(AddWorkspacePriceCategoryDto workSpacePriceCategoryDto)
        {
            return await _workspaceManagementService.AddWorkspacePriceCategory(workSpacePriceCategoryDto);
        }

        [HttpPut("UpdateWorkSpacePriceCategory/{id}")]
        public async Task<BaseResponse<string>> UpdateWorkSpacePriceCategory(long id, AddWorkspacePriceCategoryDto workSpacePriceCategoryDto)
        {
            return await _workspaceManagementService.UpdateWorkspacePriceCategory(id, workSpacePriceCategoryDto);
        }

        [HttpDelete("DeleteWorkSpacePriceCategory/{id}")]
        public async Task<BaseResponse<string>> DeleteWorkSpacePriceCategory(long id)
        {
            return await _workspaceManagementService.DeleteWorkspacePriceCategory(id);
        }

        [HttpGet("GetWorkSpacePriceCategory/{id}")]
        public async Task<BaseResponse<GetWorkspacePriceCategoryDto>> GetWorkSpacePriceCategory(long id)
        {
            return await _workspaceManagementService.GetWorkspacePriceCategory(id);
        }

        [HttpGet("GetWorkSpacePriceCategories")]
        public async Task<BaseResponse<List<GetWorkspacePriceCategoryDto>>> GetWorkSpacePriceCategories()
        {
            return await _workspaceManagementService.GetAllWorkspacePriceCategories();
        }


    }
}
