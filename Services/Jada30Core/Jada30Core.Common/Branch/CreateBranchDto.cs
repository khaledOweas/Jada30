namespace Jada30Core.Common.Branch
{
    public class CreateBranchDto
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public long AdministrativeRegionId { get; set; }
        public long WebsiteBranchId { get; set; }
        public string WorkingDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long CategoryBranchId { get; set; }
        public ICollection<CreateBranchComponentDto>? BranchComponents { get; set; } = new List<CreateBranchComponentDto>();
    }
}
