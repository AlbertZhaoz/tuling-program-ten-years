using Volo.Abp.Settings;

namespace Abp.Albert.Bussiness.Settings;

public class BussinessSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BussinessSettings.MySetting1));
    }
}
