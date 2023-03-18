using Abp.Albert.Bussiness.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Albert.Bussiness.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BussinessController : AbpControllerBase
{
    protected BussinessController()
    {
        LocalizationResource = typeof(BussinessResource);
    }
}
