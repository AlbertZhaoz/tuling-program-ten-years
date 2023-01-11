using Albert.MicroService.TeamService.Models;

namespace Albert.MicroService.TeamService.Repositories
{
    /// <summary>
    /// 团队仓储接口
    /// </summary>
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamById(int id);
        void Create(Team team);
        void Update(Team team);
        void Delete(Team team);
        bool TeamExists(int id);
    }
}
