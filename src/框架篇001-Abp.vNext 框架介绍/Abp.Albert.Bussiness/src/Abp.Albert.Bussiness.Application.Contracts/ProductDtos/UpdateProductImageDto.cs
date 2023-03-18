namespace Abp.Albert.Bussiness.ProductDtos;

public class UpdateProductImageDto
{
    public int ImageSort { set; get; } // 排序
    public string ImageStatus { set; get; } // 状态（1：启用，2：禁用）
    public string ImageUrl { set; get; } // 图片url
}