using Albert.MicroService.TeamService.Models;
using Microsoft.EntityFrameworkCore;

namespace Albert.MicroService.TeamService.Context;

/// <summary>
/// 团队服务上下文
/// </summary>
public class TeamContext:DbContext
{
    public TeamContext(DbContextOptions<TeamContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
}