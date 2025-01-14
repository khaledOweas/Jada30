using Lookup.Common.BaseResponse;

using Lookups.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;

namespace Lookups.API.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class LookupController : ControllerBase
{

    private readonly ILogger<LookupController> _logger;
    private readonly LookupsContext _context;

    public LookupController(LookupsContext context, ILogger<LookupController> logger)
    {
        this._context = context;
        _logger = logger;
    }

    [HttpGet]
    public BaseResponse<List<Domain.Entities.Lookup>> GetAllCategory()
    {
        try
        {
            var lookups = _context.Lookups.Where(x => x.InternalRef == null).ToList();
            return new SuccessResponse<List<Domain.Entities.Lookup>>("Lookups retrieved successfully.", lookups);
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<Domain.Entities.Lookup>>("An error occurred while retrieving lookups.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }
    [HttpGet]
    public BaseResponse<List<Domain.Entities.Lookup>> GetAll()
    {
        try
        {
            var lookups = _context.Lookups.ToList();
            return new SuccessResponse<List<Domain.Entities.Lookup>>("Lookups retrieved successfully.", lookups);
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<Domain.Entities.Lookup>>("An error occurred while retrieving lookups.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpGet("{refCode}")]
    public BaseResponse<List<Domain.Entities.Lookup>> GetAll(string refCode)
    {
        try
        {
            var lookups = _context.Lookups.Where(x => x.InternalRef == refCode).ToList();
            return new SuccessResponse<List<Domain.Entities.Lookup>>("Lookups retrieved successfully.", lookups);
        }
        catch (Exception ex)
        {
            return new FailedResponse<List<Domain.Entities.Lookup>>("An error occurred while retrieving lookups by reference code.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpGet("{code}")]
    public BaseResponse<Domain.Entities.Lookup> Get(string code)
    {
        try
        {
            var lookup = _context.Lookups.FirstOrDefault(x => x.InternalCode == code);
            if (lookup == null)
            {
                return new FailedResponse<Domain.Entities.Lookup>($"Lookup with code '{code}' not found.");
            }

            return new SuccessResponse<Domain.Entities.Lookup>("Lookup retrieved successfully.", lookup);
        }
        catch (Exception ex)
        {
            return new FailedResponse<Domain.Entities.Lookup>("An error occurred while retrieving the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpPost]
    public BaseResponse<Domain.Entities.Lookup> CreateLookup([FromBody] Domain.Entities.Lookup lookup)
    {
        try
        {
            if (lookup == null)
            {
                return new FailedResponse<Domain.Entities.Lookup>("Lookup data cannot be null.");
            }

            _context.Lookups.Add(lookup);
            _context.SaveChanges();

            return new SuccessResponse<Domain.Entities.Lookup>("Lookup created successfully.", lookup);
        }
        catch (Exception ex)
        {
            return new FailedResponse<Domain.Entities.Lookup>("An error occurred while creating the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
        }
    }

    [HttpPut("{code}")]
    public BaseResponse<Domain.Entities.Lookup> UpdateLookup(string code, [FromBody] Domain.Entities.Lookup updatedLookup)
    {
        try
        {
            var existingLookup = _context.Lookups.FirstOrDefault(x => x.InternalCode == code);

            if (existingLookup == null)
            {
                return new FailedResponse<Domain.Entities.Lookup>($"Lookup with code '{code}' not found.");
            }

            // this needs autoMapper . and working with DTO . instead of Entities Class 
            existingLookup.Name = updatedLookup.Name;
            existingLookup.Description = updatedLookup.Description;
            existingLookup.InternalRef = updatedLookup.InternalRef;
            existingLookup.InternalCode = updatedLookup.InternalCode;

            _context.SaveChanges();

            return new SuccessResponse<Domain.Entities.Lookup>("Lookup updated successfully.", existingLookup);
        }
        catch (Exception ex)
        {
            return new FailedResponse<Domain.Entities.Lookup>("An error occurred while updating the lookup.", new List<Errors> { new Errors { Key = ex.GetHashCode(), Value = ex.Message } });
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
