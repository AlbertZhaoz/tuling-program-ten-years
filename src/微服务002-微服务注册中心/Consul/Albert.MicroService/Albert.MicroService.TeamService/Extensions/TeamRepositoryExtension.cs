using Albert.MicroService.TeamService.Repositories;
using Albert.MicroService.TeamService.Services;

namespace Albert.MicroService.TeamService.Extensions;

public static class TeamRepositoryExtension
{
    public static void AddTeamRepository(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITeamRepository, TeamRepository>();
    }
}