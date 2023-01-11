using Albert.MicroService.TeamService.Context;
using Albert.MicroService.TeamService.Models;

namespace Albert.MicroService.TeamService.Repositories
{
    /// <summary>
    /// 团队仓储实现
    /// </summary>
    public class TeamRepository : ITeamRepository
    {
        public TeamContext teamContext;
        public TeamRepository(TeamContext teamContext)
        {
            this.teamContext = teamContext;
        }
        public void Create(Team team)
        {
            teamContext.Teams.Add(team);
            teamContext.SaveChanges();
        }

        public void Delete(Team team)
        {
            teamContext.Teams.Remove(team);
            teamContext.SaveChanges();
        }

        public Team GetTeamById(int id)
        {
            return teamContext.Teams.Find(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return teamContext.Teams.ToList();
        }

        public void Update(Team team)
        {
            teamContext.Teams.Update(team);
            teamContext.SaveChanges();
        }
        public bool TeamExists(int id)
        {
            return teamContext.Teams.Any(e => e.Id == id);
        }
    }
}
