using System;
using System.Collections.Generic;
using System.Text;
using Sureze.Localization;
using Volo.Abp.Application.Services;

namespace Sureze;

/* Inherit your application services from this class.
 */
public abstract class SurezeAppService : ApplicationService
{
    protected SurezeAppService()
    {
        LocalizationResource = typeof(SurezeResource);
    }
}
