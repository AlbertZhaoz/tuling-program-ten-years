using Abp.Albert.Bussiness.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Abp.Albert.Bussiness.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BussinessEntityFrameworkCoreModule),
    typeof(BussinessApplicationContractsModule)
    )]
public class BussinessDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
