using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IBranchManagementService
    {

        Task<BaseResponse<GetBranchDto>> AddBranch(CreateBranchDto request);
        Task<BaseResponse<GetBranchDto>> UpdateBranch(long id,CreateBranchDto request);
        Task<BaseResponse<bool>> DeleteBranch(long id);
        Task<BaseResponse<GetBranchDto>> GetBranch(long id);
        Task<BaseResponse<List<GetBranchDto>>> GetBranches();
    }
}
