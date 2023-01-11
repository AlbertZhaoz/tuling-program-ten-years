using Albert.MicroService.TeamService.Services;

namespace Albert.MicroService.TeamService.Extensions;

public static class TeamServiceExtension
{
    public static void AddTeamService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITeamService, Services.TeamService>();
    }
}