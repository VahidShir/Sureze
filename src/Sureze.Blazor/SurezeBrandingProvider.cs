using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sureze.Blazor;

[Dependency(ReplaceServices = true)]
public class SurezeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Sureze";
}
