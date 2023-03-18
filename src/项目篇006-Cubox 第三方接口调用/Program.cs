using System.Text.RegularExpressions;
using RestSharp;

var content = File.ReadAllLines(@"C:\Users\szdxz\Desktop\blog.txt");
var json = File.ReadAllText(@"C:\Users\szdxz\Desktop\cubox.json");

foreach (var element in content)
{
    Regex emailregex = new Regex("(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]");
    var title = element.Split(emailregex.Match(element).Value)[0];
    var description = element.Split(emailregex.Match(element).Value)[1];
    json = json.Replace("{value}", emailregex.Match(element).Value)
        .Replace("{title}", title)
        .Replace("{description}", description);
    HttpPost("https://cubox.pro/c/api/save/vsk6swz8ag0gfs", json);
    break;
}

void HttpPost(string url, string body)
{
    var client = new RestClient("https://cubox.pro/c/api/save/vsk6swz8ag0gfs");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    client.UserAgent = "Apifox/1.0.0 (https://www.apifox.cn)";
    request.AddHeader("Content-Type", "application/json");
    request.AddHeader("Accept", "*/*");
    request.AddHeader("Host", "cubox.pro");
    request.AddHeader("Connection", "keep-alive");
    request.AddParameter("application/json", body, ParameterType.RequestBody);
    IRestResponse response = client.Execute(request);
    Console.WriteLine(response.Content);
}