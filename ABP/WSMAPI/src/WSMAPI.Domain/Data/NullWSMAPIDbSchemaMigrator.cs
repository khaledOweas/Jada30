using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WSMAPI.Data;

/* This is used if database provider does't define
 * IWSMAPIDbSchemaMigrator implementation.
 */
public class NullWSMAPIDbSchemaMigrator : IWSMAPIDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
