using Microsoft.Extensions.Localization;
using WSMAPI.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace WSMAPI;

[Dependency(ReplaceServices = true)]
public class WSMAPIBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<WSMAPIResource> _localizer;

    public WSMAPIBrandingProvider(IStringLocalizer<WSMAPIResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
