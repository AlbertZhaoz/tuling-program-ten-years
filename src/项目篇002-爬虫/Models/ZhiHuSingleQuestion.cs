using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_FiveMinutes_002_CrawlZhiHu.Models
{
    public class ZhiHuSingleQuestion
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 回答者姓名
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 回答者头像
        /// </summary>
        public string AuthorProfileImage { get; set; }
        /// <summary>
        /// 回答者空间Url
        /// </summary>
        public string AuthorUrl { get; set; }
        /// <summary>
        /// 回答
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public string LikeNumber { get; set; }
    }
}
