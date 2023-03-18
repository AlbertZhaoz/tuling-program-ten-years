using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.Options;
using NET_FiveMinutes_002_CrawlZhihu.Common;
using NET_FiveMinutes_002_CrawlZhihu.Interfaces;
using NET_FiveMinutes_002_CrawlZhiHu.Models;

namespace NET_FiveMinutes_002_CrawlZhihu.Services
{
    public class ZhiHuService:IZhiHuService
    {
        private readonly IOptionsSnapshot<ZhiHuConfigModel> _options; // 依赖注入可选项
        private static Logger logger = new Logger(typeof(ZhiHuService));// 日志服务

        public ZhiHuService(IOptionsSnapshot<ZhiHuConfigModel> options)
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
                    @"_xsrf=R0UZVFSVifkBVdi83FrxttHEGJBupvIa; _zap=0f683c3f-dd95-4282-b436-75da3b13cc74; d_c0='AKDRMc8WThWPTty9a8IFAXzj5wZvnH92c-g=|1658797723'; _9755xjdesxxd_=32; YD00517437729195%3AWM_TID=tLPRhDDs6EpFUURRFEfUTQ6AdkDxpN%2F0; __snaker__id=HhFTKmLPPOPCsONb; gdxidpyhxdE=Rv2%5C38rtukamIySgEJSqcDUXeD7%2FZ%5CwUfqiGCkj3xqAg2sAvnPUKDPN8OpR4HYBQbu1fZwpE6vBR5VkGefKTnkE2MxwpxXxHtfeN%2BSRN%2FcmrlTMrM2hGaJExo8%2FpPQYbBs1WaE%2FjWP7I8nM7E4kDbpHQ5ElsB3kIeHbAgg%2BYY0mG%2BXLq%3A1659489209818; YD00517437729195%3AWM_NI=gMvXdTR%2Fpjc2A4g%2Fbkqe12YjrKYOwriS9jebjMI2chCjfsGd9FrUCzhNSlqs0%2F5mtkP23LpIMvyac2idDTvTlTlIZqPlU9jnUQObIAwWncj3EQNaDGkJ67zVr8NPFcJbaG0%3D; YD00517437729195%3AWM_NIKE=9ca17ae2e6ffcda170e2e6ee85db7fbcb799b6ae79bbe78bb2c15f928b9a87c86085b888b8fc749c9fbdafb42af0fea7c3b92aa593bab9e76092f1c08be23a83eca9d0e161b3bbffd3dc62b29597b0f67aab8df78be86aaa9387d3e26481b6aa94c670fb9abeb6c272ac929d8df479f4f1fb8ef76194eefdadf3438faab782e23aabbc8cb5f560b08ca4aad97b94b49bdae966978f8183cc4bb589a284e939878f8282c74da996fad8f95eb2e882b1c5698abeafa8b337e2a3; captcha_session_v2=2|1:0|10:1659488310|18:captcha_session_v2|88:aGxMMXZWRjB6MkNKYndkMVN5OU96N2tKWFlaQnArazAzVkh4bHRoWEFlRThncWpreVV3RHA1UlRtM3dENnpoSw==|4feff04875b20e8281dd46ad8855bf8593c301d033f9083732888c4e0a3ca91f; captcha_ticket_v2=2|1:0|10:1659488318|17:captcha_ticket_v2|704:eyJ2YWxpZGF0ZSI6IkNOMzFfaWpCd2FmVFd2c3hKdFllSEVlR0NGYk1CaDJhWWpzLmJBQ3VpY3dpTFpfYUw4UFptMWROR1ZqcFZmckhfbjFlOWNZdnpiSkI5SnhYZlI0c1NBZkNWbGFmZUViMUJwVzE2a1hwVDBibE1GZUNCWktWMTUyLXp1N2JwY1RULXlWMWtUVXdfQWRtbC1oUnhVU2tBaHlpMlhFTHpCVTVqUHBBQ1lJaDc4Lmh6X0gubjJvdUM5WC1nTmREWHpnLWhLR2ZiaXdHNGJKYU1jVUFsZGZLbGJKUENoRTdQNGxwQjQuckg1SGlPbDQubVBmOGlmMHpNaEFmTTJpbUdLV19tRlVKdUpTN1FLcXJwanZkaWduX2VvOW9Tc0w3UWxVeEhrREZIZU5lVDZLNUdxY2FaRVd3T2NfSE5fakpvLnpmZllWVThoOGhtS3piblZXMi1TTG1NaGlaNkNvclZTSWdRUThEb1ZwbXpBRjRSczl5QmJpR2JfMmJta3Y0MWNKNVU0cFpqc0NUWW5fY1B6clAxT1BhSVg3eDlfenpleEdPT1hvVW5uT3lNNGFmbl9ncm5mNEcxVDhlb1JxU29Kd21xbEFwa2laVVk5RjdCWnBnWHA0dlpQNGRWc2tnQklfT2FpWTgxTDEuMEUxX0NkMXBScm9paFdOSW1vZnpCLlphMyJ9|2289e43b922c0380cc5025ec84486e9792d42fd0a29bcf49cc5ac462305560ec; z_c0=2|1:0|10:1659488319|4:z_c0|92:Mi4xRDkzVENRQUFBQUFBb05FeHp4Wk9GU1lBQUFCZ0FsVk5QaGJYWXdEVEVPb3lfZ05JUzZQQURycmJma3htV0J0YnBR|159096ca73b244497120935de51e64c591e96b12cc47a6c5d7b2e660b4de714d; q_c1=69ee6bdcc64a4d9bab66891dab30e527|1659488319000|1659488319000; Hm_lvt_98beee57fd2ef70ccdd5ca52b9740c49=1659488309,1660011908,1660290989,1660370219; tst=h; NOT_UNREGISTER_WAITING=1; SESSIONID=jIfycLWxQ1WgCqpS56IyGnxMkVQSYCd890xmosCCrk4; JOID=UV4QC0pj2QydWakFB2kul_WLtEwUDJNn7TjgUXIw7Vj3E9pwV0eL__RerwsDXiM7O3mhZBb8G-a468M3QPn99FI=; osd=UFgTAE9i3w-WXKgDBGIrlvOIv0kVCpBs6DnmUnk17F70GN9xUUSA-vVYrAAGXyU4MHygYhX3Hue-6MgyQf_-_1c=; Hm_lpvt_98beee57fd2ef70ccdd5ca52b9740c49=1660378233; KLBRSID=2177cbf908056c6654e972f5ddc96dc2|1660378238|1660369664");
                request.Headers.Add("sec-ch-ua", _options.Value.SecChUa);
                request.Headers.Add("sec-ch-ua-mobile", _options.Value.SecChUaMobile);
                request.Headers.Add("sec-fetch-dest", _options.Value.SecFetchDest);
                request.Headers.Add("sec-fetch-mode", _options.Value.SecFetchMode);

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

        public List<ZhiHuHotModel> CrawlHot()
        {
            var hots = new List<ZhiHuHotModel>();
            var url = _options.Value.Url[0];
            // 开始下载Html
            var html = DownloadUrl(url);
            // 使用HtmlAgilityPack分析Html
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            // 取热榜div
            var hotDivPath = "//div/section/div[2]";
            var hotNodeList = doc.DocumentNode.SelectNodes(hotDivPath);
            var id = 1;
            foreach (var node in hotNodeList)
            {
                var hotTitlePath = "//a/h2";
                var hotUrlPath = "//div/a";
                var hotDescriptionPath = "//div/a/p";
                var hotPath = "//div/div";
                string secondHtml = node.OuterHtml;

                // 使用HtmlAgilityPack继续分析div里面的内容，取出Url和标题
                if (secondHtml != null)
                {
                    try
                    {
                        var secondDoc = new HtmlAgilityPack.HtmlDocument();
                        secondDoc.LoadHtml(secondHtml);
                        var hotTitleNode = secondDoc.DocumentNode.SelectSingleNode(hotTitlePath).InnerText;
                        var hotUrlNode = secondDoc.DocumentNode.SelectSingleNode(hotUrlPath).Attributes["href"].Value;
                        var hotDescriptionNode = "";
                        if (secondDoc.DocumentNode.SelectSingleNode(hotDescriptionPath) != null)
                        {
                            hotDescriptionNode = secondDoc.DocumentNode.SelectSingleNode(hotDescriptionPath).InnerText;
                        }
                        var hotNode = secondDoc.DocumentNode.SelectSingleNode(hotPath).InnerText;
                        hots.Add(new ZhiHuHotModel() { Id = id, hot = hotNode, Title = hotTitleNode, Url = hotUrlNode, Description = hotDescriptionNode });
                        id++;
                    }
                    catch (Exception exception)
                    {
                        logger.Error(exception.Message);
                    }
                }
                else
                {
                    logger.Error("Html为空");
                }
            }
            return hots;
        }
        public List<ZhiHuSingleQuestion> CrawlSingleQuestion(string questionID)
        {
            var hots = new List<ZhiHuSingleQuestion>();
            var url = _options.Value.Url[1]+questionID;
            // 开始下载Html
            var html = DownloadUrl(url);
            // 使用HtmlAgilityPack分析Html
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            // 取回答div
            var hotDivPath = "//*[@class='QuestionAnswers-answers']";
            var hotDivNode = doc.DocumentNode.SelectSingleNode(hotDivPath);
            
            // 取总回答数
            var totalAnswer = "/div/div/div/div/h4/span";
            var totalAnswerNode = doc.DocumentNode.SelectSingleNode(hotDivPath+ totalAnswer);


            // 获取包装好回答div
            var firstAnswerPath = "//*[@class='ContentItem AnswerItem']";
            var answerNodeList = doc.DocumentNode.SelectNodes(firstAnswerPath);
            var i = 1;

            foreach (var answerNode in answerNodeList)
            {
                string thirdHtml = answerNode.OuterHtml;
                var answerInfoDoc = new HtmlAgilityPack.HtmlDocument();
                answerInfoDoc.LoadHtml(thirdHtml);

                // 获取回答者信息div
                var authorInfoPath = "//*[@class='AuthorInfo']/meta";
                var authorName = answerInfoDoc.DocumentNode.SelectNodes(authorInfoPath)[0].Attributes["content"].Value;
                var authorProfileImage = answerInfoDoc.DocumentNode.SelectNodes(authorInfoPath)[1].Attributes["content"].Value;
                var authorUrl = answerInfoDoc.DocumentNode.SelectNodes(authorInfoPath)[2].Attributes["content"].Value;
                var answerPath = "//*[@class='RichContent-inner']/span/p";
                var answer = answerInfoDoc.DocumentNode.SelectSingleNode(answerPath).InnerText;
                hots.Add(new ZhiHuSingleQuestion()
                {
                    Id = i,
                    AuthorName = authorName,
                    AuthorProfileImage = authorProfileImage,
                    AuthorUrl = authorUrl,
                    Answer = answer
                }); 
                i++;
            }

            return hots;
        }
    }
}
