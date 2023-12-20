using Sureze.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sureze.Permissions;

public class SurezePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SurezePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SurezePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SurezeResource>(name);
    }
}
