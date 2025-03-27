using WSMAPI.Localization;
using Volo.Abp.Application.Services;

namespace WSMAPI;

/* Inherit your application services from this class.
 */
public abstract class WSMAPIAppService : ApplicationService
{
    protected WSMAPIAppService()
    {
        LocalizationResource = typeof(WSMAPIResource);
    }
}
