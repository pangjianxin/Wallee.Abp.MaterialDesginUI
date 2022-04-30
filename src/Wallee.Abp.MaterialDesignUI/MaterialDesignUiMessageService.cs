using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.DependencyInjection;

namespace Wallee.Abp.MaterialDesignUI
{
    [Dependency(ReplaceServices = true)]
    public class MaterialDesignUiMessageService : IUiMessageService, IScopedDependency
    {

        private readonly IDialogService _dialogService;
        private readonly IStringLocalizer<AbpUiResource> _localizer;

        public MaterialDesignUiMessageService(IDialogService dialogService,
            IStringLocalizer<AbpUiResource> localizer)
        {
            _dialogService = dialogService;
            _localizer = localizer;
        }

        public async Task<bool> Confirm(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var result = await _dialogService.ShowMessageBox(
                title, message, yesText: _localizer["Yes"], noText: _localizer["No"]);
            return result ?? false;
        }

        public Task Error(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            _dialogService.ShowMessageBox(title, message, yesText: _localizer["Ok"]);
            return Task.CompletedTask;
        }

        public Task Info(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            _dialogService.ShowMessageBox(title, message, yesText: _localizer["Ok"]);
            return Task.CompletedTask;
        }

        public Task Success(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            _dialogService.ShowMessageBox(title, message, yesText: _localizer["Ok"]);
            return Task.CompletedTask;
        }

        public Task Warn(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            _dialogService.ShowMessageBox(title, message, yesText: _localizer["Ok"]);
            return Task.CompletedTask;
        }
    }
}
