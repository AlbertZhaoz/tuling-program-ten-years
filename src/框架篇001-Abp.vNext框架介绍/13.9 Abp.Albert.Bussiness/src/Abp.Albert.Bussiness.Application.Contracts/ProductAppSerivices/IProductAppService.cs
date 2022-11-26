using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Albert.Bussiness.ProductDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Albert.Bussiness.ProductAppSerivices
{
    public interface IProductAppService : ICrudAppService<ProductDto, Guid, PagedAndSortedResultRequestDto,CreateProductDto,UpdateProductDto>
    {
        // 根据商品标题查询商品
        Task<IEnumerable<ProductDto>> GetProductByNameAsync(string ProductTitle);
        // 查询所有商品和商品图片
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
