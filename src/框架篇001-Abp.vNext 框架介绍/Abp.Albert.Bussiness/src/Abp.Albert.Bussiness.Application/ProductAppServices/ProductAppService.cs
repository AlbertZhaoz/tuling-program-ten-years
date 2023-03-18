using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Albert.Bussiness.ProductAppSerivices;
using Abp.Albert.Bussiness.ProductDtos;
using Abp.Albert.Bussiness.Products;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abp.Albert.Bussiness.ProductAppServices
{
    [AllowAnonymous]
    public class ProductAppService:CrudAppService<Product,ProductDto,Guid,PagedAndSortedResultRequestDto,CreateProductDto,UpdateProductDto>,IProductAppService
    {
        public IProductRepository _productRepository;
        public ProductAppService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetProductByNameAsync(string ProductTitle)
        {
            // 通过仓储接口获取商品
           var products = await _productRepository.GetProductByNameAsync(ProductTitle);
           var productsDto = ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
           return productsDto;
        }

        [AllowAnonymous]
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            // 通过仓储接口获取商品
            var products = await _productRepository.GetAllProducts();
            var productsDto = ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            return productsDto;
        }
    }
}
