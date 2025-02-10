using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using Jada30Core.Common.PriceCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IPriceCategoriesManagementService
    {

        Task<BaseResponse<GetPriceCategory>> AddPriceCategory(AddPriceCategory request);
        Task<BaseResponse<GetPriceCategory>> UpdatePriceCategory(long id, AddPriceCategory request);
        Task<BaseResponse<bool>> DeletePriceCategory(long id);
        Task<BaseResponse<GetPriceCategory>> GetPriceCategory(long id);
        Task<BaseResponse<List<GetPriceCategory>>> GetPriceCategories();
        Task<BaseResponse<string>> ToggelPublish(long id);
    }
}
