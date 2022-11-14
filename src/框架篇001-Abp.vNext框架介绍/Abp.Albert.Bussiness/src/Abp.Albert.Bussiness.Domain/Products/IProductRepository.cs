using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Abp.Albert.Bussiness.Products
{
    public interface IProductRepository:IRepository<Product,Guid>
    {
        // 根据商品标题查询商品
        Task<IEnumerable<Product>> GetProductByNameAsync(string ProductTitle);
        // 查询所有商品和商品图片
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
