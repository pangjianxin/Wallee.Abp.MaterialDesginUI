using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign;

public class AbpMaterialDesignThemeOptions
{
    public MenuOptions Menu { get; set; }

    public AbpMaterialDesignThemeOptions()
    {
        Menu = new MenuOptions();
    }
}

public class MenuOptions
{
    public MenuPlacement Placement { get; set; }

    public MenuOptions()
    {
        Placement = MenuPlacement.Left;
    }
}
