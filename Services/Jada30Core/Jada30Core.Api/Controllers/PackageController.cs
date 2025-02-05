using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Package;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jada30Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PackageController : ControllerBase
    {
       
        private readonly IPackageManagementService _packageManagementService;
        public PackageController(IPackageManagementService packageManagementService)
        {
            _packageManagementService = packageManagementService;
        }


        [HttpGet("GetPackages")]
        public async Task<BaseResponse<List<GetPackageDto>>> GetPackages()
        {
            return await _packageManagementService.GetAllPackagesAsync();
        }

        [HttpPost("CreatePackage")]
        public async Task<BaseResponse<string>> CreatePackage(AddPackageDto packageDto)
        {
            return await _packageManagementService.CreatePackageAsync(packageDto);
        }

        [HttpPut("UpdatePackage/{id}")]
        public async Task<BaseResponse<string>> UpdatePackage(int id, AddPackageDto packageDto)
        {
            return await _packageManagementService.UpdatePackageAsync(id, packageDto);
        }

        [HttpDelete("DeletePackage/{id}")]
        public async Task<BaseResponse<string>> DeletePackage(int id)
        {
            return await _packageManagementService.DeletePackageAsync(id);
        }

        [HttpGet("GetPackage/{id}")]
        public async Task<BaseResponse<GetPackageDto>> GetPackage(int id)
        {
            return await _packageManagementService.GetPackageByIdAsync(id);
        }

    }
}
