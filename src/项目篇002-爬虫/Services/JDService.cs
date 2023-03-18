using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using NET_FiveMinutes_002_CrawlZhihu.Common;
using NET_FiveMinutes_002_CrawlZhihu.Interfaces;
using NET_FiveMinutes_002_CrawlZhihu.Models;
using NET_FiveMinutes_002_CrawlZhiHu.Models;
using Newtonsoft.Json;

namespace NET_FiveMinutes_002_CrawlZhihu.Services
{
    public class JDService:IJDService
    {
        private readonly IOptionsSnapshot<JDConfigModel> _options; // 依赖注入可选项
        private static Logger logger = new Logger(typeof(ZhiHuService));// 日志服务
        private int _Number = 1;
        private List<string> skuIdList = new List<string>();
        private List<JDCommodity> commodityList = new List<JDCommodity>();

        public JDService(IOptionsSnapshot<JDConfigModel> options)
        {
            _options = options;
        }
        public string DownloadUrl(string url)
        {
            string html = string.Empty;
            try
            {
                //https可以下载
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                {
                    return true; //总是接受  
                });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求
                request.Timeout = _options.Value.Timeout;//设置30s的超时
                request.UserAgent = _options.Value.UserAgent; //手机端 = "User - Agent:Mozilla / 5.0(iPhone; CPU iPhone OS 7_1_2 like Mac OS X) App leWebKit/ 537.51.2(KHTML, like Gecko) Version / 7.0 Mobile / 11D257 Safari / 9537.53";
                request.ContentType = _options.Value.ContentType;// "text/html;charset=gbk";// 
                request.Headers.Add("Cookie",
                    @"__jdu=1658929491905355745740; __jdv=76161171|www.google.com.hk|-|referral|-|1660437957175; areaId=12; PCSYCityID=CN_320000_320500_0; shshshfpa=e632858e-4202-c32f-ea79-27f787789b5e-1660437958; shshshfpb=iG4vLKFHIK7tnGOGRh3kHAA; rkv=1.0; __jdc=122270672; jsavif=0; ipLoc-djd=12-988-993-58088; mt_xid=V2_52007VwMVVlRQUVIaQRlUBGMBFlZbXVZcGkgpXQ00V0VXCl1OXUpJTkAAZAFHTlVbWlgDTExdBWcCEVpfUFsJL0oYXwZ7AhtOXV1DWhlCGl4OYwQiUG1YYlwbThldDG8FFlBtWFReGw%3D%3D; __jda=122270672.1658929491905355745740.1658929492.1660467386.1660472778.5; wlfstk_smdl=8upsn0uha5z7wxc0q8wzmx1aa0k2tww1; TrackID=1q0veF2tlJpbS3RAWOyJXwkDy8iWkg7XPVX4Laj4WY9N9FeJIWWvPXwYZFsGuopLcGbAHDYJDbuBR_RbcY7pRepKh0Ru4dnvgBw8vAItX3wb6Y7J_QuFzf_GOLUbhDzeC; thor=306B8A9E06D406DB95F380580B84A6EEDDE8A3B52D54E5F93F24563EEA150DFAF11D894874E833281C96C958F80066B923C75F913D949EAA601BEE8F0CD55098B2CD18F184317306BBD1D3AF61B74ED2ED9848611EA4AD1F3674516A44CBDBAF6BD14B6740A0E5E7013041C92E86CD04A302BD7E5A9C132B835D0B2F4E688C85DA2EE680742C76DBC8B4D07ECE66002BBD69988C7A354137640A967AE5A023FE; pinId=03xIoebuRLVbm3fGvVo8ZbV9-x-f3wj7; pin=jd_56f2a1161b775; unick=AlbertZhaoz; ceshi3.com=000; _tp=MyPBk07KwATRO6t0Y4HmUaL9Eg4uHwvasXV2it2HYOc%3D; logining=1; _pst=jd_56f2a1161b775; shshshfp=4d3dbdaf92f87a59175a2d2a448b2128; __jdb=122270672.6.1658929491905355745740|5.1660472778; shshshsID=3bfb502d976281fa98f57813ebb194fb_2_1660472818338; qrsc=3; 3AB9D23F7A4B3C9B=F7KPONZWDMNLRPSOBSS65WTDZFBYKJNTIOI567Q764GW5ZXYMID6XVEDAEOCPLEWH2BNCQODGUJB3KVS5UBYZEKNFM");
                //request.Headers.Add("Cookie",
                //@"_xsrf=R0UZVFSVifkBVdi83FrxttHEGJBupvIa; _zap=0f683c3f-dd95-4282-b436-75da3b13cc74; d_c0='AKDRMc8WThWPTty9a8IFAXzj5wZvnH92c-g=|1658797723'; _9755xjdesxxd_=32; YD00517437729195%3AWM_TID=tLPRhDDs6EpFUURRFEfUTQ6AdkDxpN%2F0; __snaker__id=HhFTKmLPPOPCsONb; gdxidpyhxdE=Rv2%5C38rtukamIySgEJSqcDUXeD7%2FZ%5CwUfqiGCkj3xqAg2sAvnPUKDPN8OpR4HYBQbu1fZwpE6vBR5VkGefKTnkE2MxwpxXxHtfeN%2BSRN%2FcmrlTMrM2hGaJExo8%2FpPQYbBs1WaE%2FjWP7I8nM7E4kDbpHQ5ElsB3kIeHbAgg%2BYY0mG%2BXLq%3A1659489209818; YD00517437729195%3AWM_NI=gMvXdTR%2Fpjc2A4g%2Fbkqe12YjrKYOwriS9jebjMI2chCjfsGd9FrUCzhNSlqs0%2F5mtkP23LpIMvyac2idDTvTlTlIZqPlU9jnUQObIAwWncj3EQNaDGkJ67zVr8NPFcJbaG0%3D; YD00517437729195%3AWM_NIKE=9ca17ae2e6ffcda170e2e6ee85db7fbcb799b6ae79bbe78bb2c15f928b9a87c86085b888b8fc749c9fbdafb42af0fea7c3b92aa593bab9e76092f1c08be23a83eca9d0e161b3bbffd3dc62b29597b0f67aab8df78be86aaa9387d3e26481b6aa94c670fb9abeb6c272ac929d8df479f4f1fb8ef76194eefdadf3438faab782e23aabbc8cb5f560b08ca4aad97b94b49bdae966978f8183cc4bb589a284e939878f8282c74da996fad8f95eb2e882b1c5698abeafa8b337e2a3; captcha_session_v2=2|1:0|10:1659488310|18:captcha_session_v2|88:aGxMMXZWRjB6MkNKYndkMVN5OU96N2tKWFlaQnArazAzVkh4bHRoWEFlRThncWpreVV3RHA1UlRtM3dENnpoSw==|4feff04875b20e8281dd46ad8855bf8593c301d033f9083732888c4e0a3ca91f; captcha_ticket_v2=2|1:0|10:1659488318|17:captcha_ticket_v2|704:eyJ2YWxpZGF0ZSI6IkNOMzFfaWpCd2FmVFd2c3hKdFllSEVlR0NGYk1CaDJhWWpzLmJBQ3VpY3dpTFpfYUw4UFptMWROR1ZqcFZmckhfbjFlOWNZdnpiSkI5SnhYZlI0c1NBZkNWbGFmZUViMUJwVzE2a1hwVDBibE1GZUNCWktWMTUyLXp1N2JwY1RULXlWMWtUVXdfQWRtbC1oUnhVU2tBaHlpMlhFTHpCVTVqUHBBQ1lJaDc4Lmh6X0gubjJvdUM5WC1nTmREWHpnLWhLR2ZiaXdHNGJKYU1jVUFsZGZLbGJKUENoRTdQNGxwQjQuckg1SGlPbDQubVBmOGlmMHpNaEFmTTJpbUdLV19tRlVKdUpTN1FLcXJwanZkaWduX2VvOW9Tc0w3UWxVeEhrREZIZU5lVDZLNUdxY2FaRVd3T2NfSE5fakpvLnpmZllWVThoOGhtS3piblZXMi1TTG1NaGlaNkNvclZTSWdRUThEb1ZwbXpBRjRSczl5QmJpR2JfMmJta3Y0MWNKNVU0cFpqc0NUWW5fY1B6clAxT1BhSVg3eDlfenpleEdPT1hvVW5uT3lNNGFmbl9ncm5mNEcxVDhlb1JxU29Kd21xbEFwa2laVVk5RjdCWnBnWHA0dlpQNGRWc2tnQklfT2FpWTgxTDEuMEUxX0NkMXBScm9paFdOSW1vZnpCLlphMyJ9|2289e43b922c0380cc5025ec84486e9792d42fd0a29bcf49cc5ac462305560ec; z_c0=2|1:0|10:1659488319|4:z_c0|92:Mi4xRDkzVENRQUFBQUFBb05FeHp4Wk9GU1lBQUFCZ0FsVk5QaGJYWXdEVEVPb3lfZ05JUzZQQURycmJma3htV0J0YnBR|159096ca73b244497120935de51e64c591e96b12cc47a6c5d7b2e660b4de714d; q_c1=69ee6bdcc64a4d9bab66891dab30e527|1659488319000|1659488319000; Hm_lvt_98beee57fd2ef70ccdd5ca52b9740c49=1659488309,1660011908,1660290989,1660370219; tst=h; NOT_UNREGISTER_WAITING=1; SESSIONID=jIfycLWxQ1WgCqpS56IyGnxMkVQSYCd890xmosCCrk4; JOID=UV4QC0pj2QydWakFB2kul_WLtEwUDJNn7TjgUXIw7Vj3E9pwV0eL__RerwsDXiM7O3mhZBb8G-a468M3QPn99FI=; osd=UFgTAE9i3w-WXKgDBGIrlvOIv0kVCpBs6DnmUnk17F70GN9xUUSA-vVYrAAGXyU4MHygYhX3Hue-6MgyQf_-_1c=; Hm_lpvt_98beee57fd2ef70ccdd5ca52b9740c49=1660378233; KLBRSID=2177cbf908056c6654e972f5ddc96dc2|1660378238|1660369664");
                //request.Headers.Add("sec-ch-ua", _options.Value.SecChUa);
                //request.Headers.Add("sec-ch-ua-mobile", _options.Value.SecChUaMobile);
                //request.Headers.Add("sec-fetch-dest", _options.Value.SecFetchDest);
                //request.Headers.Add("sec-fetch-mode", _options.Value.SecFetchMode);

                //request.Host = _options.Value.Host;
                //request.Headers.Add("Cookie",_options.Value.Cookie);
                //request.Headers.Add("Accept", _options.Value.Accept);
                //request.Headers.Add("Accept-Encoding", _options.Value.AcceptEncoding);
                //request.Headers.Add("Referer", _options.Value.Referer);



                //如何自动读取cookie
                //request.CookieContainer = new CookieContainer();//1 给请求准备个container
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Warn(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            //string sessionValue = response.Cookies["ASP.NET_SessionId"].Value;//2 读取cookie
                            //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312
                            var enc = Encoding.UTF8;
                            StreamReader sr = new StreamReader(response.GetResponseStream(), enc);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format($"DownloadHtml抓取{url}失败"), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    logger.Error("远程服务器返回错误: (306)。", ex);
                    html = null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }

        public List<JDCommodity> GetJDCategory(JDCategory category)
        {
            CrawlJDCategory(category);
            return commodityList;
        }

        private void CrawlJDCategory(JDCategory category)
        {
            try
            {
                if (string.IsNullOrEmpty(category.Url))
                {
                    logger.Warn(string.Format("Url为空,Name={0} Level={1} Url={2}", category.Name, category.CategoryLevel, category.Url));
                    return;
                }
                string html = DownloadUrl(category.Url);//下载html
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);

                    //{
                    //    string path = @"//*[@id='brand-11026']/a";
                    //    var node = document.DocumentNode.SelectSingleNode(path);
                    //    string title = node.Attributes["title"].Value;
                    //}
                    {
                        string path = "//*[@class=\"J_valueList v-fixed\"]/li";
                        var nodeCollection = document.DocumentNode.SelectNodes(path);
                        //foreach (var node in nodeCollection)
                        //{
                        //    Console.WriteLine(node.Id);
                        //}
                    }
                    {
                        //分页：分析--->尝试---->测试--->分析--->尝试---->测试
                        string rootUrl = category.Url;
                        //1 找总页数---超出后是展示的最后一页
                        {
                            string totalPagePath = @"//*[@id='J_topPage']/span/i";
                            HtmlNode node = document.DocumentNode.SelectSingleNode(totalPagePath);
                            var sPage = int.Parse(node.InnerText);//共330页
                            for (int i = 1; i <= sPage; i++)
                            {
                                string url = $"{rootUrl}&Page={i}";
                                //分别去读取每一页
                                this.FindCommodityPage(url);
                                this.FindPrice();
                            }
                        }
                    }
                }

                //{
                //    HtmlDocument doc = new HtmlDocument();
                //    doc.LoadHtml(html);//加载html
                //    string pageNumberPath = @"//*[@id='J_topPage']/span/i";
                //    HtmlNode pageNumberNode = doc.DocumentNode.SelectSingleNode(pageNumberPath);
                //    if (pageNumberNode != null)
                //    {
                //        string sNumber = pageNumberNode.InnerText;
                //        for (int i = 1; i < int.Parse(sNumber) + 1; i++)
                //        {
                //            string pageUrl = string.Format("{0}&page={1}", category.Url, i);
                //            try
                //            {
                //                GetCommodityList(commodityList,category, pageUrl.Replace("&page=1&", string.Format("&page={0}&", i)));
                //                //commodityRepository.SaveList(commodityList);
                //            }
                //            catch (Exception ex)//保证一页的错误不影响另外一页
                //            {
                //                logger.Error("Crawler的commodityRepository.SaveList(commodityList)出现异常", ex);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
                logger.Warn(string.Format("出现异常,Name={0} Level={1} Url={2}", category.Name, category.CategoryLevel, category.Url));
            }
        }

        private void FindCommodityPage(string url)
        {
            string html = DownloadUrl(url);
            //1 一页有60个商品--图片-名称-价格-地址-id
            //  //*[@id="plist"]/ul/li[1]/div/div[1]/a/img---图片
            //  5个属性*60个全文查找   可能有性能延迟

            //2 先定位60个数据，然后再分别找5个属性   性能会比上面的好
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            string cPath = "//*[@id='J_goodsList']/ul/li";
            var nodes = document.DocumentNode.SelectNodes(cPath);
            foreach (var node in nodes)
            {
                //string htmlSingle = node.OuterHtml;
                this.FindCommoditySingle(node);
            }
        }

        /// <summary>
        /// 找到商品信息：价格，图片Url
        /// </summary>
        /// <param name="node"></param>
        private void FindCommoditySingle(HtmlNode node)//可以直接传递node
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(node.OuterHtml);
            node = htmlDocument.DocumentNode;

            {
                string namePath = "//*[@class=\"p-name p-name-type-3\"]/a/em";
                HtmlNode nameNode = node.SelectSingleNode(namePath);
                string name = nameNode.InnerText;

                string urlPath = "//*[@class=\"p-name p-name-type-3\"]/a";
                HtmlNode urlNode = node.SelectSingleNode(urlPath);
                string url = $"https:{urlNode.Attributes["href"].Value}";
                if (url.Contains("dsp"))
                {
                    urlPath = "//*[@class=\"p-name p-name-type-3\"]/a/i";
                    urlNode = node.SelectSingleNode(urlPath);
                    url = $"https:{urlNode.Attributes["id"].Value.LastIndexOf('_')}";
                }

                string picturePath = "//*[@class=\"p-img\"]/a/img";
                HtmlNode pictureNode = node.SelectSingleNode(picturePath);

                string pictureUrl = null;
                if (pictureNode == null)
                {
                    Console.WriteLine("图片节点为空");
                }
                else if (pictureNode.Attributes["src"] == null)
                {
                    //延迟-惰性加载，其实是js框架去完成的，
                    //一开始只展示电脑屏幕可见的图片，其他图片不加载的---提升性能
                    //滚动页面，js完成新的图片加载，就是把url绑定到src属性，浏览器就会自动加载
                    pictureUrl = $"https:{pictureNode.Attributes["data-lazy-img"].Value}";
                    //Console.WriteLine("图片节点src为空");
                }
                //所见非所得
                else
                {
                    pictureUrl = $"https:{pictureNode.Attributes["src"].Value}";
                }

                string pricePath = "//*[@class=\"p-price\"]/strong/i";
                HtmlNode priceNode = node.SelectSingleNode(pricePath);
                if (priceNode == null)
                {
                    Console.WriteLine("价格节点为空");
                }
                else
                {
                    //价格自然是动态获取+绑定，ajax请求
                    //ajax：js发起的一个基于XmlHttpRequest
                    string sPrice = priceNode.InnerText;
                }
                //https://item.jd.com/5436676.html
                string skuId = url.Substring(url.LastIndexOf('/') + 1).Replace(".html", "");
                this.skuIdList.Add(skuId);
                this.commodityList.Add(new JDCommodity()
                {
                    ProductId = this._Number,
                    Title = name,
                    Url = url,
                    ImageUrl = pictureUrl
                });
                _Number++;
            }
        }

        /// <summary>
        /// 发现是动态加载---分析请求---模拟请求---解读结果
        /// </summary>
        private void FindPrice()
        {
            //默认部分+id==就是id+价格
            //string url = @"https://p.3.cn/prices/mgets?callback=jQuery601918&ext=11101100&pin=&type=1&area=1_72_4137_0&skuIds=J_6761475%2CJ_5436676%2CJ_1717383%2CJ_4001283%2CJ_4934808%2CJ_978182%2CJ_4903580%2CJ_4800757%2CJ_2755894%2CJ_4492700%2CJ_8789282%2CJ_2696054%2CJ_100000504034%2CJ_1228509%2CJ_100000680783%2CJ_8090176%2CJ_100000146026%2CJ_1459104%2CJ_4903500%2CJ_8024545%2CJ_1237950%2CJ_2946309%2CJ_2823476%2CJ_647623%2CJ_4376393%2CJ_1955691%2CJ_3518399%2CJ_7188014%2CJ_6242758%2CJ_979270&pdbp=0&pdtk=&pdpin=&pduid=1547017423787904333783&source=list_pc_front&_=1551878675317";

            string idString = string.Join("%2C", this.skuIdList.Select(id => $"J_{id}"));
            string url = $"https://p.3.cn/prices/mgets?callback=jQuery601918&ext=11101100&pin=&type=1&area=1_72_4137_0&skuIds={idString}&pdbp=0&pdtk=&pdpin=&pduid=1547017423787904333783&source=list_pc_front&_=1551878675317";
            string jsonPrice = DownloadUrl(url);
        }


        private void GetCommodityList(List<JDCommodity> commodityList,JDCategory category, string url)
        {
            string html = DownloadUrl(url);
            try
            {
                if (string.IsNullOrEmpty(html)) return;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string liPath = "//*[@id='plist']/ul/li";
                HtmlNodeCollection noneNodeList = doc.DocumentNode.SelectNodes(liPath);
                if (noneNodeList == null || noneNodeList.Count == 0)
                {
                    logger.Warn(string.Format("GetCommodityList商品数据为空,Name={0} Level={1} category.Url={2} url={3}", category.Name, category.CategoryLevel, category.Url, url));
                    return;
                }
                foreach (var node in noneNodeList)
                {
                    HtmlDocument docChild = new HtmlDocument();
                    docChild.LoadHtml(node.OuterHtml);

                    JDCommodity commodity = new JDCommodity()
                    {
                        CategoryId = category.Id
                    };

                    string urlPath = "//*[@class='p-name']/a";
                    HtmlNode urlNode = docChild.DocumentNode.SelectSingleNode(urlPath);
                    if (urlNode == null)
                    {
                        continue;
                    }
                    commodity.Url = urlNode.Attributes["href"].Value;
                    if (!commodity.Url.StartsWith("http:"))
                        commodity.Url = "http:" + commodity.Url;

                    string sId = Path.GetFileName(commodity.Url).Replace(".html", "");
                    commodity.ProductId = long.Parse(sId);

                    //*[@id="plist"]/ul/li[1]/div/div[3]/a/em
                    string titlePath = "//*[@class='p-name']/a/em";
                    HtmlNode titleNode = docChild.DocumentNode.SelectSingleNode(titlePath);
                    if (titleNode == null)
                    {
                        //Log.Error(titlePath);
                        continue;
                    }
                    commodity.Title = titleNode.InnerText;

                    string iamgePath = "//*[@class='p-img']/a/img";
                    HtmlNode imageNode = docChild.DocumentNode.SelectSingleNode(iamgePath);
                    if (imageNode == null)
                    {
                        continue;
                    }
                    //前后不一
                    if (imageNode.Attributes.Contains("src"))
                        commodity.ImageUrl = imageNode.Attributes["src"].Value;
                    else if (imageNode.Attributes.Contains("original"))
                        commodity.ImageUrl = imageNode.Attributes["original"].Value;
                    else if (imageNode.Attributes.Contains("data-lazy-img"))
                        commodity.ImageUrl = imageNode.Attributes["data-lazy-img"].Value;
                    else
                    {
                        continue;
                    }
                    if (!commodity.ImageUrl.StartsWith("http:"))
                        commodity.ImageUrl = "http:" + commodity.ImageUrl;

                    string pricePath = "//*[@class='p-price']/strong/i";
                    HtmlNode priceNode = docChild.DocumentNode.SelectSingleNode(pricePath);
                    if (priceNode == null)
                    {
                        continue;
                    }
                    else
                    {
                    }
                    commodityList.Add(commodity);
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("GetCommodityList出现异常,url={0}", url), ex);
            }
            commodityList =  GetCommodityPrice(category, commodityList);
        }

        /// <summary>
        /// 对商品价格进行处理
        /// </summary>
        /// <param name="commodityList"></param>
        /// <returns></returns>
        private List<JDCommodity> GetCommodityPrice(JDCategory category, List<JDCommodity> commodityList)
        {
            try
            {
                if (commodityList == null || commodityList.Count() == 0)
                    return commodityList;

                StringBuilder sb = new StringBuilder();
                sb.Append(@"http://p.3.cn/prices/mgets?my=list_price&type=1&area=1_72_4137&skuIds=");
                sb.Append(string.Join("%2C", commodityList.Select(c => string.Format("J_{0}", c.ProductId))));
                //
                //sb.AppendFormat("http://p.3.cn/prices/mgets?callback=jQuery1069298&type=1&area=1_72_4137_0&skuIds={0}&pdbp=0&pdtk=&pdpin=&pduid=1945966343&_=1469022843655", string.Join("%2C", commodityList.Select(c => string.Format("J_{0}", c.ProductId))));
                string html = DownloadUrl(sb.ToString());
                if (string.IsNullOrWhiteSpace(html))
                {
                    logger.Warn(string.Format("获取url={0}时获取的html为空", sb.ToString()));
                }
                if (html.IndexOf("(") > -1)
                    html = html.Substring(html.IndexOf("(") + 1);
                if (html.IndexOf(")") > -1)
                    html = html.Substring(0, html.LastIndexOf(")"));
                List<JDCommodityPrice> priceList = JsonConvert.DeserializeObject<List<JDCommodityPrice>>(html);
                commodityList.ForEach(c => c.Price = priceList.FirstOrDefault(p => p.id.Equals(string.Format("J_{0}", c.ProductId))).p);
                //commodityList.ForEach(c => Console.WriteLine(" Title={0}  ImageUrl={1} Url={2} Price={3} Id={4}", c.Title, c.ImageUrl, c.Url, c.Price, c.Id));
            }
            catch (Exception ex)
            {
                logger.Error("GetCommodityPrice出现异常", ex);
            }
            return commodityList;
        }
    }
}
