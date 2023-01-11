using Albert.MicroService.TeamService.Models;

namespace Albert.MicroService.TeamService.Services
{
    /// <summary>
    /// 团队服务接口
    /// </summary>
    public interface ITeamService
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamById(int id);
        void Create(Team team);
        void Update(Team team);
        void Delete(Team team);
        bool TeamExists(int id);
    }
}
