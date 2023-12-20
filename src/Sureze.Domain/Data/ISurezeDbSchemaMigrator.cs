using System.Threading.Tasks;

namespace Sureze.Data;

public interface ISurezeDbSchemaMigrator
{
    Task MigrateAsync();
}
