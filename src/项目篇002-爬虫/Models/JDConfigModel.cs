using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_FiveMinutes_002_CrawlZhihu.Models
{
    public class JDConfigModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Timeout { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Encoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecChUa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecChUaMobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecFetchDest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecFetchMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Accept { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AcceptEncoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Referer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Url { get; set; }
    }
}
