namespace NET_FiveMinutes_002_CrawlZhihu.Models
{
    public class JDCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int CategoryLevel { get; set; }
        public int State { get; set; }
    }
}
