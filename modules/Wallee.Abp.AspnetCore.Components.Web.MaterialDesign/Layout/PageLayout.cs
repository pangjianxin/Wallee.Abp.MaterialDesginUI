using MudBlazor;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Volo.Abp.DependencyInjection;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Layout;

public class PageLayout : IScopedDependency, INotifyPropertyChanged
{
    private string _title;

    // TODO: Consider using this property for setting Page Title too.
    public virtual string Title
    {
        get => _title;
        set
        {
            _title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }

    public virtual ObservableCollection<BreadcrumbItem> BreadcrumbItems { get; set; } = new();

    public virtual ObservableCollection<PageToolbarItem> ToolbarItems { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;
}
