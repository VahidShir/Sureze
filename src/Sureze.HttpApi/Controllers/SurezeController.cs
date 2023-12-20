using Sureze.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sureze.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SurezeController : AbpControllerBase
{
    protected SurezeController()
    {
        LocalizationResource = typeof(SurezeResource);
    }
}
