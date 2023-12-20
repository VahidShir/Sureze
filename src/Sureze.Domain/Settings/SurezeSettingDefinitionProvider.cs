using Volo.Abp.Settings;

namespace Sureze.Settings;

public class SurezeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SurezeSettings.MySetting1));
    }
}
