using Consul;

namespace Albert.MicroService.Core.Consul.Registry
{
    /// <summary>
    /// consul服务注册实现
    /// </summary>
    public class ConsulServiceRegistry : IServiceRegistry
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceNode"></param>
        public void Register(ServiceRegistryConfig serviceNode)
        {
            // 1、创建consul客户端连接
            var consulClient = new ConsulClient(configuration =>
            {
                //1.1 建立客户端和服务端连接
                configuration.Address = new Uri(serviceNode.RegistryAddress);
            });

            // 2、获取服务内部地址

            // 3、创建consul服务注册对象
            var registration = new AgentServiceRegistration()
            {
                ID = serviceNode.Id,
                Name = serviceNode.Name,
                Address = serviceNode.Address,
                Port = serviceNode.Port,
                Tags = serviceNode.Tags,
                Check = new AgentServiceCheck
                {
                    // 3.1、consul健康检查超时间
                    Timeout = TimeSpan.FromSeconds(10),
                    // 3.2、服务停止5秒后注销服务
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    // 3.3、consul健康检查地址
                    HTTP = serviceNode.HealthCheckAddress,
                    // 3.4 consul健康检查间隔时间
                    Interval = TimeSpan.FromSeconds(10),
                }
            };

            // 4、注册服务
            consulClient.Agent.ServiceRegister(registration).Wait();

            // 5、关闭连接
            consulClient.Dispose();
        }

        /// <summary>
        /// 注销服务
        /// </summary>
        /// <param name="serviceNode"></param>
        public void Deregister(ServiceRegistryConfig serviceNode)
        {
            // 1、创建consul客户端连接
            var consulClient = new ConsulClient(configuration =>
            {
                //1.1 建立客户端和服务端连接
                configuration.Address = new Uri(serviceNode.RegistryAddress);
            });

            // 2、注销服务
            consulClient.Agent.ServiceDeregister(serviceNode.Id);

            // 3、关闭连接
            consulClient.Dispose();
        }

    }
}
