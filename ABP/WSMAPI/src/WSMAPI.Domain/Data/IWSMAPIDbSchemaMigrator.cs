using System.Threading.Tasks;

namespace WSMAPI.Data;

public interface IWSMAPIDbSchemaMigrator
{
    Task MigrateAsync();
}
