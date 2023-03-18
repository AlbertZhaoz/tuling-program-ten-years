using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.DTOs;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop.Common
{
    public static class BatchConfigsExtensions
    {
        public static void InitBatchConfigsExtensions(ServiceCollection Services)
        {
            // 创建配置文件读取项
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Configs\\AlbertToolHelperDesktop.json",false,true)
                .Build(); 
            Services.AddOptions().Configure<PushDto>(e=>configuration.GetSection("PushDto").Bind(e));
        }
    }
}
