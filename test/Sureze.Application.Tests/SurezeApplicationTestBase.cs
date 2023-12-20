using Volo.Abp.Modularity;

namespace Sureze;

public abstract class SurezeApplicationTestBase<TStartupModule> : SurezeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
