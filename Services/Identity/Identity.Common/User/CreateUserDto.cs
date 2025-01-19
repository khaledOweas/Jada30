using Identity.Common.Role;

namespace Identity.Common.User;
public class CreateUserDto
{
    public string? UserName { get; set; }
    public string? UserNameAr { get; set; }
    public string? PhoneNumber { get; set; }
    public IList<string> RoleNames { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }

}

public class UserDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? UserNameAr { get; set; }
    public string Email { get; set; }
    public string phoneNumber { get; set; }
    public IList<RoleDto> Roles { get; set; }

}
