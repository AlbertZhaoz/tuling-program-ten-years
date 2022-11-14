using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Albert.Bussiness.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Albert.Bussiness.Products
{
    [Dependency(ServiceLifetime.Transient)]
    public class ProductRepository: EfCoreRepository<BussinessDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<BussinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            // 第二种查询方式: Abp.vNext 封装好的
            // 连表查询
            return GetDbSetAsync().Result.Include(product => product.ProductImages).ToList();
        }

        // 通过名字来获取全部的商品
        public async Task<IEnumerable<Product>> GetProductByNameAsync(string ProductTitle)
        {
            // 第一种方式:EFCore查询方式 数据库所有产品
            var dbContext = await GetDbContextAsync();
            var productsBydbContext = dbContext.Products.Where(p => p.ProductTitle == ProductTitle);
            return productsBydbContext;

            // 下面这种方式是执行原生的sql
            // await dbContext.Database.ExecuteSqlRawAsync($"Select * FROM Product WHERE ProductTitle = {ProductTitle}");
        }
    }
}
