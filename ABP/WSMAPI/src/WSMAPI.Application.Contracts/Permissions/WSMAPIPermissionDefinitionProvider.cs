using WSMAPI.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace WSMAPI.Permissions;

public class WSMAPIPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WSMAPIPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(WSMAPIPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WSMAPIResource>(name);
    }
}
