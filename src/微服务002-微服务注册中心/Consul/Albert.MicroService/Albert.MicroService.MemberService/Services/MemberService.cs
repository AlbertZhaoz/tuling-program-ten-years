using Albert.MicroService.TeamService.Models;
using Albert.MicroService.TeamService.Repositories;

namespace Albert.MicroService.MemberService.Services
{
    /// <summary>
    /// 团队服务实现
    /// </summary>
    public class MemberService : IMemberService
    {
        public readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public void Create(Member member)
        {
            memberRepository.Create(member);
        }

        public void Delete(Member member)
        {
            memberRepository.Delete(member);
        }

        public Member GetMemberById(int id)
        {
            return memberRepository.GetMemberById(id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return memberRepository.GetMembers();
        }
        
        public void Update(Member member)
        {
            memberRepository.Update(member);
        }

        public bool MemberExists(int id)
        {
            return memberRepository.MemberExists(id);
        }

        public IEnumerable<Member> GetMembers(int teamId)
        {
            return memberRepository.GetMembers(teamId);
        }
    }
}
