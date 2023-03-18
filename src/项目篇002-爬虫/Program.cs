using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using NET_FiveMinutes_002_CrawlZhihu.Common;
using NET_FiveMinutes_002_CrawlZhihu.Interfaces;

namespace NET_FiveMinutes_002_CrawlZhihu
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            BatchConfigs.InitConfigs();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_ZhiHu(BatchConfigs
                .Services
                .BuildServiceProvider()
                .GetRequiredService<IZhiHuService>(),
                BatchConfigs
                    .Services
                    .BuildServiceProvider()
                    .GetRequiredService<IJDService>()));
        }
    }
}
