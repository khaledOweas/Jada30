using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.BranchComponents;
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

        Task<BaseResponse<GetBranchComponentDto>> AddBranch(CreateBranchDto request);
        Task<BaseResponse<GetBranchComponentDto>> UpdateBranch(long id,CreateBranchDto request);
        Task<BaseResponse<bool>> DeleteBranch(long id);
        Task<BaseResponse<GetBranchComponentDto>> GetBranch(long id);
        Task<BaseResponse<List<GetBranchComponentDto>>> GetBranches();
    }
}
