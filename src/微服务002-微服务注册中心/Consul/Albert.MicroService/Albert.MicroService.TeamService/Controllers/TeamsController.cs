using Albert.MicroService.TeamService.Models;
using Albert.MicroService.TeamService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Albert.MicroService.TeamService.Controllers
{
   
    /// <summary>
    /// 团队微服务api
    /// </summary>
    [Route("Teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: api/Teams
        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeams()
        {
            return teamService.GetTeams().ToList();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            Team team = teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }
            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            try
            {
                teamService.Update(team);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamService.TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Team> PostTeam(Team team)
        {
            teamService.Create(team);

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public ActionResult<Team> DeleteTeam(int id)
        {
            var team = teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            teamService.Delete(team);
            return team;
        }
    }
}
