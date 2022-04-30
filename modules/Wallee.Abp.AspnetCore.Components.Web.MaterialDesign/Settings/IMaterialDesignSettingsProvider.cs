using System.Threading.Tasks;
using Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Settings;

namespace Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Settings;

public interface IMaterialDesignSettingsProvider
{
    Task<MenuPlacement> GetMenuPlacementAsync();
    Task TriggerSettingChanged();
    
    public event MaterialDesignSettingsProvider.AntDesignSettingChangedHandler SettingChanged;
}
