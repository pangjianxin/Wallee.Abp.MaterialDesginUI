using MudBlazor;
using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;
using Volo.Abp.Settings;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Settings;

public class MaterialDesignSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(MaterialDesignSettingNames.MenuPlacement, MenuPlacement.Left.ToString())
        );
    }
}
