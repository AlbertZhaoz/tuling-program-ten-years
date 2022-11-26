using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Albert.Bussiness.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public string ProductCode { set; get; }    //商品编码
    public string ProductUrl { set; get; }         // 商品主图
    public string ProductTitle { set; get; }       //商品标题
    public string ProductDescription { set; get; }     // 图文描述
    public decimal ProductVirtualprice { set; get; } //商品虚拟价格
    public decimal ProductPrice { set; get; }       //价格
    public int ProductSort { set; get; }    //商品序号
    public int ProductSold { set; get; }        //已售件数
    public int ProductStock { set; get; }       //商品库存
    public string ProductStatus { set; get; } // 商品状态
    public ICollection<ProductImage> ProductImages { set; get; }

    // 私有构造函数，用于序列化
    private Product()
    {
        ProductImages = new List<ProductImage>();
    }

    // 通过 Guid 来检索商品
    public Product(Guid id) : base(id)
    {
        ProductImages = new List<ProductImage>();
    }
}