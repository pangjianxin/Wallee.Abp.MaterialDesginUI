using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using Volo.Abp.AspNetCore.Components.Progression;

namespace Wallee.Abp.MaterialDesignUI.Components;

public partial class UiPageProgress : ComponentBase
{
    private double _percent;

    private Color _color;

    private string _style;

    [Inject]
    public IUiPageProgressService UiPageProgressService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        UiPageProgressService.ProgressChanged += OnProgressChanged;
    }

    protected virtual async void OnProgressChanged(object sender, UiPageProgressEventArgs e)
    {
        _percent = e.Percentage ?? new Random().Next(0, 100);

        SetProgressStatus(e.Options.Type);
        if (_percent is >= 0 and <= 100)
        {
            ShowProgress();
        }
        else
        {
            HideProgress();
        }

        await InvokeAsync(StateHasChanged);
    }

    protected virtual void ShowProgress()
    {
        _style = "";
    }

    protected virtual void HideProgress()
    {
        _style = "display:none;";
    }

    protected virtual void SetProgressStatus(UiPageProgressType pageProgressType)
    {
        _color = pageProgressType switch
        {
            UiPageProgressType.Info => Color.Primary,
            UiPageProgressType.Default => Color.Default,
            UiPageProgressType.Success => Color.Success,
            UiPageProgressType.Warning => Color.Warning,
            UiPageProgressType.Error => Color.Error,
            _ => Color.Error
        };
    }
}
