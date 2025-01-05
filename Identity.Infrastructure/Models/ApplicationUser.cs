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
}
