using Albert.MicroService.TeamService.Repositories;

namespace Albert.MicroService.MemberService.Extensions;

public static class MemberRepositoryExtension
{
    public static void AddMemberRepository(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMemberRepository, MemberRepository>();
    }
}