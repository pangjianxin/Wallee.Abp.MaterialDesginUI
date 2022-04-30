using System.Threading.Tasks;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.PageToolbars;

public interface IPageToolbarManager
{
    Task<PageToolbarItem[]> GetItemsAsync(PageToolbar toolbar);
}
