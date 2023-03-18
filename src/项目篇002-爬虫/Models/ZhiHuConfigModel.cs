using System.Collections.Generic;

namespace NET_FiveMinutes_002_CrawlZhiHu.Models
{
    public class ZhiHuConfigModel
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
        public List <string > Url { get; set; }
    }
}