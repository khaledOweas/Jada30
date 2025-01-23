namespace Identity.Common.Role;
public class CreateRoleWithPermssionsDto
{
    public string RoleName { get; set; }
    public List<long>? PermissionIds { get; set; }
}



