using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Albert.MicroService.Core.Consul.Models;

namespace Albert.MicroService.Core.Consul.Registry
{
    /// <summary>
    /// consul服务发现实现
    /// </summary>
    public class ConsulServiceDiscovery : IServiceDiscovery
    {
        private readonly IConfiguration configuration;
        public ConsulServiceDiscovery(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<ServiceUrl>> Discovery(string serviceName)
        {
            ServiceDiscoveryConfig serviceDiscoveryConfig = configuration.GetSection("ConsulDiscovery").Get<ServiceDiscoveryConfig>();

            // 1、创建consul客户端连接
            var consulClient = new ConsulClient(configuration =>
            {
                //1.1 建立客户端和服务端连接
                configuration.Address = new Uri(serviceDiscoveryConfig.RegistryAddress);
            });

            // 2、consul查询服务,根据具体的服务名称查询
            var queryResult = await consulClient.Catalog.Service(serviceName);

            // 3、将服务进行拼接
            var list = new List<ServiceUrl>();
            foreach (var service in queryResult.Response)
            {
                list.Add(new ServiceUrl { Url = service.ServiceAddress + ":" + service.ServicePort });
            }
            return list;
        }
    }
}
