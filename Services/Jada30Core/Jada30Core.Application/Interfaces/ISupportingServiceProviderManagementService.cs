using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.SupportingServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface ISupportingServiceProviderManagementService
    {
        Task<BaseResponse<SupportingServiceProviderDto>> CreateSupportingServiceProvider(CreateSupportingServiceProviderDto supportingServiceProvider);
        Task<BaseResponse<List<SupportingServiceProviderDto>>> GetSupportingServiceProviders();
        Task<BaseResponse<SupportingServiceProviderDto>> GetSupportingServiceProvider(long id);
        Task<BaseResponse<SupportingServiceProviderDto>> UpdateSupportingServiceProvider(long id, CreateSupportingServiceProviderDto supportingServiceProvider);
        Task<BaseResponse<bool>> DeleteSupportingServiceProvider(long id);
    }
}
