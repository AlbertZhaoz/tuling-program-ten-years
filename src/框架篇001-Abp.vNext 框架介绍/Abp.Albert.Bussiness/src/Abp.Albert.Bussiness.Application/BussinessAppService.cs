using System;
using System.Collections.Generic;
using System.Text;
using Abp.Albert.Bussiness.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Albert.Bussiness;

/* Inherit your application services from this class.
 */
public abstract class BussinessAppService : ApplicationService
{
    protected BussinessAppService()
    {
        LocalizationResource = typeof(BussinessResource);
    }
}
