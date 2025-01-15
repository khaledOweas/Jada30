namespace Identity.Common.User;
public class CreateUserDto
{
    public string? UserName { get; set; }
    public string? UserNameAr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? RoleName { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }

}

public class UserDto
{
    public string? UserNameAr { get; set; }
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }

}
