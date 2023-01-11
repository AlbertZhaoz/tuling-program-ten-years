using Albert.MicroService.Core.Consul.Models;

namespace Albert.MicroService.Core.Consul.Cluster
{
    /// <summary>
    /// 负载均衡抽象实现
    /// </summary>
    public abstract class AbstractLoadBalance : ILoadBalance
    {
        public ServiceUrl Select(IList<ServiceUrl> serviceUrls)
        {
            if (serviceUrls == null || serviceUrls.Count ==0)
                return null;
            if (serviceUrls.Count == 1)
                return serviceUrls[0];
            return DoSelect(serviceUrls);
        }

        /// <summary>
        /// 子类去实现
        /// </summary>
        /// <param name="serviceUrls"></param>
        /// <returns></returns>
        public abstract ServiceUrl DoSelect(IList<ServiceUrl> serviceUrls);
    }
}
