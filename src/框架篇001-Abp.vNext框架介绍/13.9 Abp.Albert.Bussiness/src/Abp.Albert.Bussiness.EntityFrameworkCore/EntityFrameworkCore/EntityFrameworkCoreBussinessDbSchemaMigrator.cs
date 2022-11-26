using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abp.Albert.Bussiness.Data;
using Volo.Abp.DependencyInjection;

namespace Abp.Albert.Bussiness.EntityFrameworkCore;

public class EntityFrameworkCoreBussinessDbSchemaMigrator
    : IBussinessDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBussinessDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BussinessDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BussinessDbContext>()
            .Database
            .MigrateAsync();
    }
}
