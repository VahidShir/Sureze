using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sureze.Data;

/* This is used if database provider does't define
 * ISurezeDbSchemaMigrator implementation.
 */
public class NullSurezeDbSchemaMigrator : ISurezeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
