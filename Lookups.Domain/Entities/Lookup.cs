

namespace Lookups.Domain.Entities;

public class Lookup
{
    public long Id { get; set; }

    public required string Name { get; set; }
    public required string NameAr { get; set; }

    public string? Description { get; set; }
    public string? DescriptionAr { get; set; }

    public required string InternalCode { get; set; }

    public string? InternalRef { get; set; }

    public bool IsActive { get; set; }

}