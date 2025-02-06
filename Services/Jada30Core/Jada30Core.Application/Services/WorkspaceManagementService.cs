using AutoMapper;
using Domain.WorkSpace;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Workspace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Services
{
    public class WorkspaceManagementService : IWorkspaceManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkspaceManagementService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<string>> AddWorkspaceSubCategory(AddWorkspaceSubcategoryDto request)
        {
            var response = new BaseResponse<string>();

            var workspaceSubcategory = _mapper.Map<WorkspaceSubcategory>(request);
            await _unitOfWork.GetRepository<WorkspaceSubcategory>().InsertAsync(workspaceSubcategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Subcategory created successfully.";
            response.IsSuccess = true;

            return response;
        }

        public async Task<BaseResponse<string>> AddWorkspacePriceCategory(AddWorkspacePriceCategoryDto request)
        {
            var response = new BaseResponse<string>();

            var workspacePriceCategory = _mapper.Map<WorkspacePriceCategory>(request);
            await _unitOfWork.GetRepository<WorkspacePriceCategory>().InsertAsync(workspacePriceCategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Price category created successfully.";
            response.IsSuccess = true;

            return response;
        }

        public async Task<BaseResponse<string>> AddWorkspace(AddWorkspaceDto request)
        {
            var response = new BaseResponse<string>();

            var workspace = _mapper.Map<Workspace>(request);
            await _unitOfWork.GetRepository<Workspace>().InsertAsync(workspace);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace created successfully.";
            response.IsSuccess = true;

            return response;
        }

        public async Task<BaseResponse<List<GetWorkspaceDto>>> GetAllWorkspace()
        {
            var response = new BaseResponse<List<GetWorkspaceDto>>();
            var workspaces = await _unitOfWork.GetRepository<Workspace>().GetAllAsync(x => !x.IsDeleted,include: x => x.Include(s => s.WorkspaceSubcategory).Include(x => x.WorkspaceCategory));
            response.ResponseData = _mapper.Map<List<GetWorkspaceDto>>(workspaces);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<List<GetWorkspaceSubcategoryDto>>> GetAllWorkspaceSubCategories()
        {
            var response = new BaseResponse<List<GetWorkspaceSubcategoryDto>>();
            var workspaceSubcategories = await _unitOfWork.GetRepository<WorkspaceSubcategory>().GetAllAsync(x => !x.IsDeleted,include: x => x.Include(s => s.WorkspaceCategory));
            response.ResponseData = _mapper.Map<List<GetWorkspaceSubcategoryDto>>(workspaceSubcategories);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<List<GetWorkspacePriceCategoryDto>>> GetAllWorkspacePriceCategories()
        {
            var response = new BaseResponse<List<GetWorkspacePriceCategoryDto>>();
            var workspacePriceCategories = await _unitOfWork.GetRepository<WorkspacePriceCategory>().GetAllAsync(x => !x.IsDeleted,include: x => x.Include(s => s.WorkspaceSubcategory));
            response.ResponseData = _mapper.Map<List<GetWorkspacePriceCategoryDto>>(workspacePriceCategories);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<GetWorkspaceDto>> GetWorkspace(long id)
        {
            var response = new BaseResponse<GetWorkspaceDto>();
            var workspace = (await _unitOfWork.GetRepository<Workspace>().GetAllAsync(x => x.Id == id && !x.IsDeleted,include: x => x.Include(s => s.WorkspaceSubcategory).Include(x => x.WorkspaceCategory))).FirstOrDefault();
            if (workspace == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace not found.";
                return response;
            }
            response.ResponseData = _mapper.Map<GetWorkspaceDto>(workspace);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<GetWorkspaceSubcategoryDto>> GetWorkspaceSubCategory(long Id)
        {
            var response = new BaseResponse<GetWorkspaceSubcategoryDto>();
            var workspaceSubcategory = (await _unitOfWork.GetRepository<WorkspaceSubcategory>().GetAllAsync(x => x.Id == Id && !x.IsDeleted,include: x => x.Include(s => s.WorkspaceCategory))).FirstOrDefault();
            if (workspaceSubcategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Subcategory not found.";
                return response;
            }
            response.ResponseData = _mapper.Map<GetWorkspaceSubcategoryDto>(workspaceSubcategory);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<GetWorkspacePriceCategoryDto>> GetWorkspacePriceCategory(long id)
        {
            var response = new BaseResponse<GetWorkspacePriceCategoryDto>();
            var workspacePriceCategory = (await _unitOfWork.GetRepository<WorkspacePriceCategory>().GetAllAsync(x => x.Id == id && !x.IsDeleted,include: x => x.Include(s => s.WorkspaceSubcategory))).FirstOrDefault();
            if (workspacePriceCategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Price Category not found.";
                return response;
            }
            response.ResponseData = _mapper.Map<GetWorkspacePriceCategoryDto>(workspacePriceCategory);
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<string>> UpdateWorkspace(long id, AddWorkspaceDto request)
        {
            var response = new BaseResponse<string>();
            var workspace = (await _unitOfWork.GetRepository<Workspace>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (workspace == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace not found.";
                return response;
            }
            _mapper.Map(request, workspace);
             _unitOfWork.GetRepository<Workspace>().Update(workspace);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace updated successfully.";
            response.IsSuccess = true;

            return response;
        }

        public async Task<BaseResponse<string>> UpdateWorkspaceSubCategory(long id, AddWorkspaceSubcategoryDto request)
        {
            var response = new BaseResponse<string>();
            var workspaceSubcategory = (await _unitOfWork.GetRepository<WorkspaceSubcategory>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (workspaceSubcategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Subcategory not found.";
                return response;
            }
            _mapper.Map(request, workspaceSubcategory);
            _unitOfWork.GetRepository<WorkspaceSubcategory>().Update(workspaceSubcategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace Subcategory updated successfully.";
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<string>> UpdateWorkspacePriceCategory(long id, AddWorkspacePriceCategoryDto request)
        {
            var response = new BaseResponse<string>();
            var workspacePriceCategory = (await _unitOfWork.GetRepository<WorkspacePriceCategory>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (workspacePriceCategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Price Category not found.";
                return response;
            }
            _mapper.Map(request, workspacePriceCategory);
            _unitOfWork.GetRepository<WorkspacePriceCategory>().Update(workspacePriceCategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace Price Category updated successfully.";
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<string>> DeleteWorkspace(long id)
        {
            var response = new BaseResponse<string>();
            var workspace = (await _unitOfWork.GetRepository<Workspace>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (workspace == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace not found.";
                return response;
            }
            workspace.IsDeleted = true;
            _unitOfWork.GetRepository<Workspace>().Update(workspace);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace deleted successfully.";
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<string>> DeleteWorkspaceSubCategory(long Id)
        {
            var response = new BaseResponse<string>();
            var workspaceSubcategory = (await _unitOfWork.GetRepository<WorkspaceSubcategory>().GetAllAsync(x => x.Id == Id && !x.IsDeleted)).FirstOrDefault();
            if (workspaceSubcategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Subcategory not found.";
                return response;
            }
            workspaceSubcategory.IsDeleted = true;
            _unitOfWork.GetRepository<WorkspaceSubcategory>().Update(workspaceSubcategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace Subcategory deleted successfully.";
            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse<string>> DeleteWorkspacePriceCategory(long id)
        {
            var response = new BaseResponse<string>();
            var workspacePriceCategory = (await _unitOfWork.GetRepository<WorkspacePriceCategory>().GetAllAsync(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (workspacePriceCategory == null)
            {
                response.IsSuccess = false;
                response.Message = "Workspace Price Category not found.";
                return response;
            }
            workspacePriceCategory.IsDeleted = true;
            _unitOfWork.GetRepository<WorkspacePriceCategory>().Update(workspacePriceCategory);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = "Workspace Price Category deleted successfully.";
            response.IsSuccess = true;
            return response;
        }

    }
}
