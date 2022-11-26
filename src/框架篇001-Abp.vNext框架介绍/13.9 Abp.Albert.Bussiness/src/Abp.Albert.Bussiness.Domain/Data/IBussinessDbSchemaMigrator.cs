using System.Threading.Tasks;

namespace Abp.Albert.Bussiness.Data;

public interface IBussinessDbSchemaMigrator
{
    Task MigrateAsync();
}
