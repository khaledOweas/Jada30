using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Branch;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Package;
using Jada30Core.Common.PriceCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PriceCategoryController : ControllerBase
    {
     
        private readonly IPriceCategoriesManagementService _priceCategoryManagementService;
        public PriceCategoryController(IPriceCategoriesManagementService priceCategoryManagementService)
        {
            _priceCategoryManagementService = priceCategoryManagementService;
        }


        [HttpGet("GetPriceCategories")]
        public async Task<BaseResponse<List<GetPriceCategory>>> GetPriceCategories()
        {
            return await _priceCategoryManagementService.GetPriceCategories();
        }

        [HttpPost("AddPriceCategory")]
        public async Task<BaseResponse<GetPriceCategory>> AddPriceCategory(AddPriceCategory request)
        {
            return await _priceCategoryManagementService.AddPriceCategory(request);
        }

        [HttpPut("UpdatePriceCategory/{id}")]
        public async Task<BaseResponse<GetPriceCategory>> UpdatePriceCategory(long id, AddPriceCategory request)
        {
            return await _priceCategoryManagementService.UpdatePriceCategory(id, request);
        }

        [HttpDelete("DeletePriceCategory/{id}")]
        public async Task<BaseResponse<bool>> DeletePriceCategory(long id)
        {
            return await _priceCategoryManagementService.DeletePriceCategory(id);
        }

        [HttpGet("GetPriceCategory/{id}")]
        public async Task<BaseResponse<GetPriceCategory>> GetPriceCategory(long id)
        {
            return await _priceCategoryManagementService.GetPriceCategory(id);
        }

        [HttpPut("ToggelPublish/{id}")]
        public async Task<BaseResponse<string>> ToggelPublish(long id)
        {
            return await _priceCategoryManagementService.ToggelPublish(id);
        }


    }
}
