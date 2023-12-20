using Sureze.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sureze.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SurezeEntityFrameworkCoreModule),
    typeof(SurezeApplicationContractsModule)
    )]
public class SurezeDbMigratorModule : AbpModule
{
}
