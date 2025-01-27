using AutoMapper;
using Domain;
using Infrastructure.Data;
using Lookups.Common;
using Lookups.Common.BaseResponse;


using Microsoft.AspNetCore.Mvc;

namespace Lookups.API.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class LookupController : ControllerBase
{

    private readonly ILogger<LookupController> _logger;
    private readonly Jada30Context _context;
    private readonly IMapper _Mapper;

    public LookupController(Jada30Context context, ILogger<LookupController> logger, IMapper mapper)
    {
        this._context = context;
        _logger = logger;
        _Mapper = mapper;
    }

    [HttpGet]
    public BaseResponse<List<GetLookupDto>> GetAllCategory()
    {
        try
        {
            var lookups = _context.Lookups.Where(x => x.InternalRef == null).ToList();
            var mapper = _Mapper.Map<List<GetLookupDto>>(lookups);
            return new SuccessResponse<List<GetLookupDto>>("Lookups retrieved successfully.", mapper); // Adjusted type here
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<GetLookupDto>>(
                "An error occurred while retrieving lookups.",
                new List<Errors>
                {
                new Errors { Key = ex.GetHashCode(), Value = ex.Message }
                });
        }
    }

    [HttpGet]
    public BaseResponse<List<GetLookupDto>> GetAll()
    {
        try
        {
            var lookups = _context.Lookups.ToList();
            var mapper = _Mapper.Map<List<GetLookupDto>>(lookups);
            return new SuccessResponse<List<GetLookupDto>>("Lookups retrieved successfully.", mapper); // Adjusted type here
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<GetLookupDto>>(
                "An error occurred while retrieving lookups.",
                new List<Errors>
                {
                new Errors { Key = ex.GetHashCode(), Value = ex.Message }
                });
        }
    }

    [HttpGet("{refCode}")]
    public BaseResponse<List<GetLookupDto>> GetAll(string refCode)
    {
        try
        {
            var lookups = _context.Lookups.Where(x => x.InternalRef == refCode).ToList();
            var mapper = _Mapper.Map<List<GetLookupDto>>(lookups);
            return new SuccessResponse<List<GetLookupDto>>("Lookups retrieved successfully.", mapper); // Adjusted type here
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<GetLookupDto>>(
                "An error occurred while retrieving lookups.",
                new List<Errors>
                {
                new Errors { Key = ex.GetHashCode(), Value = ex.Message }
                });
        }
    }

    [HttpGet("{code}")]
    public BaseResponse<GetLookupDto> Get(string code)
    {
        try
        {
            var lookup = _context.Lookups.FirstOrDefault(x => x.InternalCode == code);
            var mapper = _Mapper.Map<GetLookupDto>(lookup);

            if (mapper == null)
            {
                return new FailedResponse<GetLookupDto>($"Lookup with code '{code}' not found.");
            }

            return new SuccessResponse<GetLookupDto>("Lookup retrieved successfully.", mapper);
        }
        catch (Exception ex)
        {
            return new FailedResponse<GetLookupDto>("An error occurred while retrieving the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpPost]
    public BaseResponse<GetLookupDto> CreateLookup([FromBody] AddLookupDto lookup)
    {
        try
        {
            if (lookup == null)
            {
                return new FailedResponse<GetLookupDto>("Lookup data cannot be null.");
            }
            var newLookup = _Mapper.Map<Lookup>(lookup);

            _context.Lookups.Add(newLookup);
            _context.SaveChanges();
            var mapper = _Mapper.Map<GetLookupDto>(newLookup);

            return new SuccessResponse<GetLookupDto>("Lookup created successfully.", mapper);
        }
        catch (Exception ex)
        {
            return new FailedResponse<GetLookupDto>("An error occurred while creating the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpPut("{code}")]
    public BaseResponse<GetLookupDto> UpdateLookup(string code, [FromBody] UpdateLookupDto updatedLookup)
    {
        try
        {
            var existingLookup = _context.Lookups.FirstOrDefault(x => x.InternalCode == code);

            if (existingLookup == null)
            {
                return new FailedResponse<GetLookupDto>($"Lookup with code '{code}' not found.");
            }

            // this needs autoMapper . and working with DTO . instead of Entities Class 
            existingLookup.Name = updatedLookup.Name;
            existingLookup.NameAr = updatedLookup.NameAr;
            existingLookup.Description = updatedLookup.Description;
            existingLookup.DescriptionAr = updatedLookup.DescriptionAr;
            existingLookup.InternalRef = updatedLookup.InternalRef;
            existingLookup.InternalCode = updatedLookup.InternalCode;
            existingLookup.IsActive = updatedLookup.IsActive;

            _context.SaveChanges();

            var mapper = _Mapper.Map<GetLookupDto>(existingLookup);

            return new SuccessResponse<GetLookupDto>("Lookup updated successfully.", mapper);
        }
        catch (Exception ex)
        {
            return new FailedResponse<GetLookupDto>("An error occurred while updating the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpDelete("{code}")]
    public BaseResponse<bool> DeleteLookup(string code)
    {
        try
        {
            var existingLookup = _context.Lookups.FirstOrDefault(x => x.InternalCode == code);

            if (existingLookup == null)
            {
                return new FailedResponse<bool>($"Lookup with code '{code}' not found.");
            }

            _context.Lookups.Remove(existingLookup);
            _context.SaveChanges();

            return new SuccessResponse<bool>("Lookup deleted successfully.", true);
        }
        catch (Exception ex)
        {
            return new FailedResponse<bool>("An error occurred while deleting the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

}
