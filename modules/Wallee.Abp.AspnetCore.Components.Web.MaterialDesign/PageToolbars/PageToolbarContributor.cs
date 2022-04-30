using System.Threading.Tasks;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.PageToolbars;

public abstract class PageToolbarContributor : IPageToolbarContributor
{
    public abstract Task ContributeAsync(PageToolbarContributionContext context);
}
