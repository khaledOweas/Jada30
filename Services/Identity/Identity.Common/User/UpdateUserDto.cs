namespace Identity.Common.User;
public class UpdateUserDto
{
    public long Id { get; set; }
    public string? UserName { get; set; }
    public string? UserNameAr { get; set; }
    public string? PhoneNumber { get; set; }
    public IList<string> RoleNames { get; set; }
    public string? Email { get; set; } 
}
