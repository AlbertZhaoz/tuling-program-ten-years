using Abp.Albert.Bussiness.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.Albert.Bussiness;

[DependsOn(
    typeof(BussinessEntityFrameworkCoreTestModule)
    )]
public class BussinessDomainTestModule : AbpModule
{

}
