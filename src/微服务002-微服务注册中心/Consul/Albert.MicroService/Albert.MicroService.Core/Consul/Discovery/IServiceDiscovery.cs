using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Albert.MicroService.Core.Consul.Models;

namespace Albert.MicroService.Core.Consul.Registry
{
   /// <summary>
   /// 服务发现
   /// </summary>
   public interface IServiceDiscovery
   {
        /// <summary>
        /// 服务发现
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        Task<IList<ServiceUrl>> Discovery(string serviceName);
    }
}
