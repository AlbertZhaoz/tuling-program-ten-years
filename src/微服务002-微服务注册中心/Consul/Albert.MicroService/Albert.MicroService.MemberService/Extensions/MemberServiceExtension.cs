using Albert.MicroService.MemberService.Services;

namespace Albert.MicroService.TeamService.Extensions;

public static class MemberServiceExtension
{
    public static void AddMemberService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMemberService, MemberService.Services.MemberService>();
    }
}