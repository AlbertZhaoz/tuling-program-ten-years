namespace NET_FiveMinutes_002_CrawlZhihu.Models
{
    public class JDCommodity
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}
