using Albert.MicroService.TeamService.Context;
using Albert.MicroService.TeamService.Models;

namespace Albert.MicroService.TeamService.Repositories
{
    /// <summary>
    /// 成员仓储实现
    /// </summary>
    public class MemberRepository : IMemberRepository
    {
        public MemberContext teamContext;
        public MemberRepository(MemberContext teamContext)
        {
            this.teamContext = teamContext;
        }

        public void Create(Member member)
        {
            teamContext.Members.Add(member);
            teamContext.SaveChanges();
        }

        public void Delete(Member member)
        {
            teamContext.Members.Remove(member);
            teamContext.SaveChanges();
        }

        public Member GetMemberById(int id)
        {
          return teamContext.Members.Find(id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return teamContext.Members.ToList();
        }

        public void Update(Member member)
        {
            teamContext.Members.Update(member);
            teamContext.SaveChanges();
        }

        public bool MemberExists(int id)
        {
           return teamContext.Members.Any(e => e.Id == id);
        }

        public IEnumerable<Member> GetMembers(int teamId)
        {
           return teamContext.Members.Where(memeber => memeber.TeamId == teamId);
        }
    }
}
