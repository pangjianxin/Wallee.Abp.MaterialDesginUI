using System.Threading.Tasks;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}
