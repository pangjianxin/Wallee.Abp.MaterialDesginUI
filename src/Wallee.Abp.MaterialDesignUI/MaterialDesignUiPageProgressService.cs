using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Progression;
using Volo.Abp.DependencyInjection;

namespace Wallee.Abp.MaterialDesignUI
{
    [Dependency(ReplaceServices = true)]
    public class MaterialDesignUiPageProgressService : IUiPageProgressService, IScopedDependency
    {
        public event EventHandler<UiPageProgressEventArgs> ProgressChanged;

        public Task Go(int? percentage, Action<UiPageProgressOptions> options = null)
        {
            var uiPageProgressOptions = CreateDefaultOptions();
            options?.Invoke(uiPageProgressOptions);

            ProgressChanged?.Invoke(this, new UiPageProgressEventArgs(percentage, uiPageProgressOptions));

            return Task.CompletedTask;
        }

        protected virtual UiPageProgressOptions CreateDefaultOptions()
        {
            return new UiPageProgressOptions();
        }
    }
}
