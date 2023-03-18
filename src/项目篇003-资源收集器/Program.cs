using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NET_FiveMinutes_005_SqlSugarHelper.Common;
using NET_FiveMinutes_005_SqlSugarHelper.Interfaces;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Common;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.DTOs;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 批量注册服务
            BatchConfigs.InitConfigs();
            // 扩展配置
            BatchConfigsExtensions.InitBatchConfigsExtensions(BatchConfigs
                .Services);

            var sp = BatchConfigs.Services.BuildServiceProvider();
            var options = sp.GetRequiredService<IOptionsSnapshot<PushDto>>();
            var sqlService = sp.GetRequiredService<ISqlServerService>();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new MainFrm(sqlService,options));
        }
    }
}