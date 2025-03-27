using WSMAPI.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace WSMAPI.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WSMAPIEntityFrameworkCoreModule),
    typeof(WSMAPIApplicationContractsModule)
)]
public class WSMAPIDbMigratorModule : AbpModule
{
}
