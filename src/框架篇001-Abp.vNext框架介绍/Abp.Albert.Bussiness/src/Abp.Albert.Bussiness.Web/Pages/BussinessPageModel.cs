using Abp.Albert.Bussiness.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Albert.Bussiness.Web.Pages;

public abstract class BussinessPageModel : AbpPageModel
{
    protected BussinessPageModel()
    {
        LocalizationResourceType = typeof(BussinessResource);
    }
}
