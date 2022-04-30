using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Settings;

public class MaterialDesignSettingsProvider : IMaterialDesignSettingsProvider, IScopedDependency
{
    //TODO use SettingProvider instead of AbpAntDesignThemeOptions
    // [Inject]
    // protected ISettingProvider SettingProvider { get; set; }

    [Inject]
    public IOptions<AbpMaterialDesignThemeOptions> Options { get; set; }

    public delegate Task AntDesignSettingChangedHandler();

    public event AntDesignSettingChangedHandler SettingChanged;

    public Task<MenuPlacement> GetMenuPlacementAsync()
    {
        return Task.FromResult(Options.Value.Menu.Placement);
    }

    public Task TriggerSettingChanged()
    {
        return SettingChanged?.Invoke();
    }
}
