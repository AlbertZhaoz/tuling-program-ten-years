using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abp.Albert.Bussiness.ProductDtos
{
    public class CreateProductDto: FullAuditedEntityDto<Guid>
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
        // 这边要注意有商品图片对应的 DTO
        public CreateProductImageDto[] ProductImages { set; get; }// 商品图片

        // 默认设置软删除为 false，避免查询不到数据的尴尬
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
