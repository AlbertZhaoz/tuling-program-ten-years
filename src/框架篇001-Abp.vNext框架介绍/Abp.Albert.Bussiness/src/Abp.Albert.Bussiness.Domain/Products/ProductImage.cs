using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Albert.Bussiness.Products
{
    public class ProductImage:FullAuditedEntity<Guid>
    {
        public Guid ProductId { set; get; } // 商品 Id
        public int ImageSort { set; get; } // 排序
        public string ImageStatus { set; get; } // 状态（1：启用，2：禁用）
        public string ImageUrl { set; get; } // 图片url

        private ProductImage() {}

        public ProductImage(Guid id) : base(id) { }
    }
}
