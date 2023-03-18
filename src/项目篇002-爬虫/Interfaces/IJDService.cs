using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET_FiveMinutes_002_CrawlZhihu.Models;

namespace NET_FiveMinutes_002_CrawlZhihu.Interfaces
{
    public interface IJDService
    {
        string DownloadUrl(string url);
        List<JDCommodity> GetJDCategory(JDCategory category);
    }
}
