using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser() : base()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public string UserNameAr { get; set; }
    }
    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }

        public string RoleNameAr { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class RolePermission
    {
        public long RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public long PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
