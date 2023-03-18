using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace 分布式篇001_消息中间件Rabbit_MQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public void CreateProduct(string productTitle)
        {
            // 创建连接工厂
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                // RabbitMQ 默认端口和账号密码
                Port = 5672, 
                UserName = "guest",
                Password = "guest",
                //用来区分一个 RabbitMQ 实例下不同的应用范围（不建议在同一个实例下创建不同范围，直接创建多个 RabbitMQ 实例）
                VirtualHost = "/" 
            };

            using (var connection = factory.CreateConnection())
            {
                // 创建信道
                var channel = connection.CreateModel();
            }
        }
    }
}
