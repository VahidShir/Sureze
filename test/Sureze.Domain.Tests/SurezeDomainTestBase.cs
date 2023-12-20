using Volo.Abp.Modularity;

namespace Sureze;

/* Inherit from this class for your domain layer tests. */
public abstract class SurezeDomainTestBase<TStartupModule> : SurezeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
