using System.Collections.Generic;
using NET_FiveMinutes_002_CrawlZhiHu.Models;

namespace NET_FiveMinutes_002_CrawlZhihu.Interfaces
{
    public interface IZhiHuService
    {
        string DownloadUrl(string url);
        List<ZhiHuHotModel> CrawlHot();
        List<ZhiHuSingleQuestion> CrawlSingleQuestion(string questionID);
    }
}
