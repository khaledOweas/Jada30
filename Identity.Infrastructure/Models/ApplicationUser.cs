using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Models;

public class ApplicationUser : IdentityUser<long>
{
    public ApplicationUser() : base()
    {
    }

    public ApplicationUser(string userName) : base(userName)
    {
    }
}

public class ApplicationRole : IdentityRole<long>
{
    public ApplicationRole() : base()
    {
    }

    public ApplicationRole(string roleName) : base(roleName)
    {

    }

    public ICollection<RolePermission> RolePermissions { get; set; }
}

public class Permission
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; }
}

public class RolePermission
{
    public long RoleId { get; set; }
    public ApplicationRole Role { get; set; }

    public long PermissionId { get; set; }
    public Permission Permission { get; set; }
}