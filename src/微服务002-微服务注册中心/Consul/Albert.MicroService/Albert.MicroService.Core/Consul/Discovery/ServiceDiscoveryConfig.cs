using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.MicroService.Core.Consul.Registry
{
    /// <summary>
    /// 服务发现配置
    /// </summary>
    public class ServiceDiscoveryConfig
    {
        /// <summary>
        /// 服务注册地址
        /// </summary>
        public string RegistryAddress { set; get; }
    }
}
