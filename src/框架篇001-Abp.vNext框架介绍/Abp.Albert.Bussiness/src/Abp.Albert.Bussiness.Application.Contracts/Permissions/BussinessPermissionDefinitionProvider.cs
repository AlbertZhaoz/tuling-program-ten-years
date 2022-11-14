using Abp.Albert.Bussiness.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abp.Albert.Bussiness.Permissions;

public class BussinessPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BussinessPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BussinessPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BussinessResource>(name);
    }
}
