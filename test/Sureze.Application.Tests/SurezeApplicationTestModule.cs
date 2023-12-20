using Volo.Abp.Modularity;

namespace Sureze;

[DependsOn(
    typeof(SurezeApplicationModule),
    typeof(SurezeDomainTestModule)
)]
public class SurezeApplicationTestModule : AbpModule
{

}
