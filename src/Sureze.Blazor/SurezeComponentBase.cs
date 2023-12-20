using Sureze.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Sureze.Blazor;

public abstract class SurezeComponentBase : AbpComponentBase
{
    protected SurezeComponentBase()
    {
        LocalizationResource = typeof(SurezeResource);
    }
}
