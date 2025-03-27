using WSMAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace WSMAPI.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WSMAPIController : AbpControllerBase
{
    protected WSMAPIController()
    {
        LocalizationResource = typeof(WSMAPIResource);
    } 

}
