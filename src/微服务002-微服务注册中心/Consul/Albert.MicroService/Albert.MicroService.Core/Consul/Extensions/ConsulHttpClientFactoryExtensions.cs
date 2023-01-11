using Albert.MicroService.Core.Consul.Cluster;
using Albert.MicroService.Core.Consul.Registry.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace Albert.MicroService.Core.Consul.ConsulHttpClient
{
    /// <summary>
    /// HttpClientFactory Consul下的扩展
    /// </summary>
    public static class ConsulHttpClientFactoryExtensions
    {
        public static IServiceCollection AddHttpClientConsul<ConsulHttpClient>(this IServiceCollection services) where ConsulHttpClient : class
        {
            // 1、注册 consul
            services.AddConsulDiscovery();

            // 2、注册服务负载均衡
            services.AddSingleton<ILoadBalance, RandomLoadBalance>();

            // 3、注册 Httpclient
            services.AddSingleton<ConsulHttpClient>();

            return services;
         }
    }
}
