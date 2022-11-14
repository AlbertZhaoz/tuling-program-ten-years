using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Abp.Albert.Bussiness.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BussinessDbContextFactory : IDesignTimeDbContextFactory<BussinessDbContext>
{
    public BussinessDbContext CreateDbContext(string[] args)
    {
        BussinessEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        // 这边使用了 UseMySql 来进行数据库连接
        var builder = new DbContextOptionsBuilder<BussinessDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);

        return new BussinessDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Abp.Albert.Bussiness.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
