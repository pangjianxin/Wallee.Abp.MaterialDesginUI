using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallee.Abp.MaterialDesignUI;

namespace Wallee.Abp.AspnetCore.Components.Web.MaterialDesign.Layout
{
    public partial class AbpPageHeader : ComponentBase
    {
        protected List<RenderFragment> ToolbarItemRenders { get; set; }

        public IPageToolbarManager PageToolbarManager { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool BreadcrumbShowHome { get; set; } = true;

        [Parameter]
        public bool BreadcrumbShowCurrent { get; set; } = true;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public List<BreadcrumbItem> BreadcrumbItems { get; set; }

        [Parameter]
        public PageToolbar Toolbar { get; set; }

        public AbpPageHeader()
        {
            ToolbarItemRenders = new List<RenderFragment>();
            BreadcrumbItems = new List<AbpBreadcrumbItem>();
            _breadcrumbItems = new List<BreadcrumbItem>();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (Toolbar != null)
            {
                if (!Options.Value.RenderToolbar)
                {
                    return;
                }

                var toolbarItems = await PageToolbarManager.GetItemsAsync(Toolbar);
                ToolbarItemRenders.Clear();

                foreach (var item in toolbarItems)
                {
                    var sequence = 0;
                    ToolbarItemRenders.Add(builder =>
                    {
                        builder.OpenComponent(sequence, item.ComponentType);
                        if (item.Arguments != null)
                        {
                            foreach (var argument in item.Arguments)
                            {
                                sequence++;
                                builder.AddAttribute(sequence, argument.Key, argument.Value);
                            }
                        }
                        builder.CloseComponent();
                    });
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
