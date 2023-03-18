using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Albert.Bussiness.Web;

[Dependency(ReplaceServices = true)]
public class BussinessBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bussiness";
}
