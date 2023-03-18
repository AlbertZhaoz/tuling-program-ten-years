using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_FiveMinutes_002_CrawlZhiHu.Models
{
    public class ZhiHuHotModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 热榜火热程度
        /// </summary>
        public string hot { get; set; }
        /// <summary>
        /// 热榜标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 热榜Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 热榜描述
        /// </summary>

        public string Description { get; set; }
    }
}
