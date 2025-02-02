using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IPackageManagementService
    {

         Task<BaseResponse<GetPackageDto>> GetPackageByIdAsync(int id);
         Task<BaseResponse<List<GetPackageDto>>> GetAllPackagesAsync();
        Task<BaseResponse<string>> CreatePackageAsync(AddPackageDto package);
        Task<BaseResponse<string>> UpdatePackageAsync(long id, AddPackageDto package);
        Task<BaseResponse<string>> DeletePackageAsync(int id);
    }
}
