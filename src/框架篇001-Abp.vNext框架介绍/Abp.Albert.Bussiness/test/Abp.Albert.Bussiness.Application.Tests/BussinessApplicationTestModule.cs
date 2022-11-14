using Volo.Abp.Modularity;

namespace Abp.Albert.Bussiness;

[DependsOn(
    typeof(BussinessApplicationModule),
    typeof(BussinessDomainTestModule)
    )]
public class BussinessApplicationTestModule : AbpModule
{

}
