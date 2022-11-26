using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.Albert.Bussiness.Data;

/* This is used if database provider does't define
 * IBussinessDbSchemaMigrator implementation.
 */
public class NullBussinessDbSchemaMigrator : IBussinessDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
