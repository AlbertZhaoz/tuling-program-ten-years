using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albert.MicroService.TeamService.Models;
using Albert.MicroService.TeamService.Repositories;

namespace Albert.MicroService.TeamService.Services
{
    /// <summary>
    /// 团队服务实现
    /// </summary>
    public class TeamService: ITeamService
    {
        public readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public void Create(Team team)
        {
            teamRepository.Create(team);
        }

        public void Delete(Team team)
        {
            teamRepository.Delete(team);
        }

        public Team GetTeamById(int id)
        {
            return teamRepository.GetTeamById(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return teamRepository.GetTeams();
        }

        public void Update(Team team)
        {
            teamRepository.Update(team);
        }

        public bool TeamExists(int id)
        {
            return teamRepository.TeamExists(id);
        }
    }
}
