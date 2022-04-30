using System.Threading.Tasks;
using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Themes.MaterialDesign;

public partial class DefaultLayout
{
    [Inject]
    protected IMaterialDesignSettingsProvider AntDesignSettingsProvider { get; set; }

    protected bool Collapsed { get; set; }

    protected MenuPlacement MenuPlacement { get; set; }

    protected MudTheme MenuTheme { get; set; }

    protected string HeaderClass { get; set; }

    protected SiderTheme SiderTheme { get; set; }

    protected string SiderStyle { get; set; } = "min-width:256px";

    protected override async Task OnInitializedAsync()
    {
        await SetLayout();
        AntDesignSettingsProvider.SettingChanged += OnSettingChanged;
    }

    protected virtual async Task OnSettingChanged()
    {
        await SetLayout();
        await InvokeAsync(StateHasChanged);
    }

    private async Task SetLayout()
    {
        MenuTheme = await AntDesignSettingsProvider.GetMenuThemeAsync();
        MenuPlacement = await AntDesignSettingsProvider.GetMenuPlacementAsync();

        SiderTheme = MenuTheme == MenuTheme.Light ? SiderTheme.Light : SiderTheme.Dark;
        HeaderClass = MenuPlacement == MenuPlacement.Top ? "ant-design-header-top" : "ant-design-header-left";
        HeaderClass = MenuTheme == MenuTheme.Light ? $"{HeaderClass} {HeaderClass}-light" : HeaderClass;
    }

    protected virtual void OnCollapse()
    {
        Collapsed = !Collapsed;
        SiderStyle = Collapsed ? "" : "min-width:256px";
    }
}
