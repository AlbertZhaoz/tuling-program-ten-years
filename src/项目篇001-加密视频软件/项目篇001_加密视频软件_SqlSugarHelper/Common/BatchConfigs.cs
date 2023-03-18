using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NET_FiveMinutes_005_SqlSugarHelper.Models;
using Scrutor;

namespace NET_FiveMinutes_005_SqlSugarHelper.Common
{
    public static class BatchConfigs
    {
        public static ServiceCollection Services  { get; set; }
        public static void InitConfigs()
        {
            // 创建配置文件读取项
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("CfgFiles\\DbConnect.json",false,true)
                .Build(); 

            // 将Json文件绑定到类中
            Services = new ServiceCollection();
            Services.AddOptions().Configure<DbConnectModel>(e => configuration.Bind(e))
                .Configure<SqlServerStr>(e => configuration.GetSection("SqlServerStr").Bind(e))
                .Configure<MySQLStr>(e => configuration.GetSection("MySQLStr").Bind(e));
            
            // 批量注册DI服务
            Services.Scan(scan => scan
                .FromAssemblies(Assembly.GetAssembly(typeof(BatchConfigs)))
                .AddClasses(classes =>
                    classes.Where(t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))) // 批量增加
                .UsingRegistrationStrategy(RegistrationStrategy.Skip) // 当重复添加则跳过
                .AsMatchingInterface()
                .WithScopedLifetime()
            );
        }
    }
}
