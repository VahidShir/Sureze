using Volo.Abp.Modularity;

namespace Sureze;

[DependsOn(
    typeof(SurezeDomainModule),
    typeof(SurezeTestBaseModule)
)]
public class SurezeDomainTestModule : AbpModule
{

}
