using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Abp.Albert.Bussiness.Web.Pages;

public class IndexModel : BussinessPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
