using Albert.MicroService.Core.Consul.Models;

namespace Albert.MicroService.Core.Consul.Cluster
{
    /// <summary>
    /// 服务负载均衡
    /// </summary>
    public interface ILoadBalance
    {
        /// <summary>
        /// 服务选择
        /// </summary>
        /// <param name="serviceUrls"></param>
        /// <returns></returns>
        ServiceUrl Select(IList<ServiceUrl> serviceUrls);
    }
}
