using Albert.MicroService.TeamService.Models;
using Microsoft.EntityFrameworkCore;

namespace Albert.MicroService.TeamService.Context
{
    /// <summary>
    /// 团队服务上下文
    /// </summary>
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
