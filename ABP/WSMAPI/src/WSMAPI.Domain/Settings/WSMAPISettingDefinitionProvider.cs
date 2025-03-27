using Volo.Abp.Settings;

namespace WSMAPI.Settings;

public class WSMAPISettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WSMAPISettings.MySetting1));
    }
}
