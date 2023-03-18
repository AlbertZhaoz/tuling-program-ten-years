using Abp.Albert.Bussiness.ProductDtos;
using Abp.Albert.Bussiness.Products;
using AutoMapper;
using Volo.Abp.Application.Dtos;

namespace Abp.Albert.Bussiness;

public class BussinessApplicationAutoMapperProfile : Profile
{
    public BussinessApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // 从仓储层查询出来映射到前端 DTO
        CreateMap<Product, PagedAndSortedResultRequestDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductImage, ProductImageDto>();

        // 从前端 DTO 传递给后端
        CreateMap<ProductDto, Product>();
        CreateMap<PagedAndSortedResultRequestDto, Product>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<ProductImageDto, ProductImage>();
        CreateMap<CreateProductImageDto, ProductImage>();
        CreateMap<UpdateProductImageDto, ProductImage>();
    }
}
