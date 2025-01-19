namespace Identity.Common.Role;
public class CreateRoleDto
{
    public string Name { get; set; }
    public string RoleNameAr { get; set; }
}


public class UpdateRoleDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string RoleNameAr { get; set; }
}

public class RoleDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string RoleNameAr { get; set; }
}
