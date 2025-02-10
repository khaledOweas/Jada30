using AutoMapper;
using Domain;
using Framework;
using Jada30Core.Application.Interfaces;
using Jada30Core.Common.BaseResponse;
using Jada30Core.Common.Package;
using Microsoft.EntityFrameworkCore;

namespace Jada30Core.Application.Services
{
    public class PackageManagementService : IPackageManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PackageManagementService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<string>> CreatePackageAsync(AddPackageDto package)
        {
            var response = new BaseResponse<string>();
         
            var packageEntity = _mapper.Map<Package>(package);
            await _unitOfWork.GetRepository<Package>().InsertAsync(packageEntity);
            await _unitOfWork.SaveChangesAsync();
            response.ResponseData = packageEntity.Id.ToString();
            response.IsSuccess = true;
           
            return response;
        }

        public async Task<BaseResponse<string>> DeletePackageAsync(int id)
        {
            var response = new BaseResponse<string>();
          
            var package = (await _unitOfWork.GetRepository<Package>().GetAllAsync(x => x.Id == id)).FirstOrDefault();
            if (package == null)
            {
                response.Message = "Package not found";
                return response;
            }
            package.IsDeleted = true;
            _unitOfWork.GetRepository<Package>().Update(package);
            await _unitOfWork.SaveChangesAsync();
            response.IsSuccess = true;
            
            return response;
        }

        public async Task<BaseResponse<List<GetPackageDto>>> GetAllPackagesAsync()
        {
            var response = new BaseResponse<List<GetPackageDto>>();
          
            var packages = await _unitOfWork.GetRepository<Package>().GetAllAsync(include: x => x.Include(x => x.PackageFacilities).ThenInclude(x => x.Facility).Include(x => x.PackageFacilities).ThenInclude(x => x.Type));
            response.ResponseData = _mapper.Map<List<GetPackageDto>>(packages);
            response.IsSuccess = true;
            
            return response;
        }

        public async Task<BaseResponse<GetPackageDto>> GetPackageByIdAsync(int id)
        {
            var response = new BaseResponse<GetPackageDto>();
          
            var package = (await _unitOfWork.GetRepository<Package>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.PackageFacilities).ThenInclude(x => x.Facility).Include(x => x.PackageFacilities).ThenInclude(x => x.Type))).FirstOrDefault();
            if (package == null)
            {
                response.Message = "Package not found";
                return response;
            }
            response.ResponseData = _mapper.Map<GetPackageDto>(package);
            response.IsSuccess = true;
            
            return response;
        }

        public async Task<BaseResponse<string>> UpdatePackageAsync(long id, AddPackageDto package)
        {
            var response = new BaseResponse<string>();
         
            var packageEntity = (await _unitOfWork.GetRepository<Package>().GetAllAsync(x => x.Id == id, include: x => x.Include(x => x.PackageFacilities).ThenInclude(x => x.Facility).Include(x => x.PackageFacilities).ThenInclude(x => x.Type))).FirstOrDefault();
            if (packageEntity == null)
            {
                response.Message = "Package not found";
                return response;
            }
         
            _mapper.Map(package, packageEntity);
            _unitOfWork.GetRepository<Package>().Update(packageEntity);
            await _unitOfWork.SaveChangesAsync();
            response.IsSuccess = true;
           
            return response;
        }

    }
}
