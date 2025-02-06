using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IWorkspaceManagementService
    {

        Task<BaseResponse<string>> AddWorkspace(AddWorkspaceDto request);
        Task<BaseResponse<string>> AddWorkspacePriceCategory(AddWorkspacePriceCategoryDto request);
        Task<BaseResponse<string>> AddWorkspaceSubCategory(AddWorkspaceSubcategoryDto request);
        Task<BaseResponse<string>> UpdateWorkspaceSubCategory(long id, AddWorkspaceSubcategoryDto request);
        Task<BaseResponse<string>> UpdateWorkspace(long id, AddWorkspaceDto request);
        Task<BaseResponse<string>> UpdateWorkspacePriceCategory(long id, AddWorkspacePriceCategoryDto request);
        Task<BaseResponse<string>> DeleteWorkspaceSubCategory(long Id);
        Task<BaseResponse<string>> DeleteWorkspacePriceCategory(long Id);
        Task<BaseResponse<string>> DeleteWorkspace(long Id);
        Task<BaseResponse<GetWorkspaceDto>> GetWorkspace(long Id);
        Task<BaseResponse<GetWorkspaceSubcategoryDto>> GetWorkspaceSubCategory(long Id);
        Task<BaseResponse<GetWorkspacePriceCategoryDto>> GetWorkspacePriceCategory(long Id);

        Task<BaseResponse<List<GetWorkspaceDto>>> GetAllWorkspace();
        Task<BaseResponse<List<GetWorkspacePriceCategoryDto>>> GetAllWorkspacePriceCategories();
        Task<BaseResponse<List<GetWorkspaceSubcategoryDto>>> GetAllWorkspaceSubCategories();


    }
}
