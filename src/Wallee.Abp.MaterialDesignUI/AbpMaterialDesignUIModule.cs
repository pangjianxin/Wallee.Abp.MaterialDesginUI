using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Wallee.Abp.MaterialDesignUI;

[DependsOn(
typeof(AbpAspNetCoreComponentsWebModule),
typeof(AbpDddApplicationContractsModule),
typeof(AbpAuthorizationModule)
)]
public class AbpMaterialDesignUIModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMudServices();
        context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
    }
}
