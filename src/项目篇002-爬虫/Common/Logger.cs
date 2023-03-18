using System;
using System.IO;
using log4net.Config;
using log4net;

namespace NET_FiveMinutes_002_CrawlZhihu.Common
{
    public class Logger
    {
        static Logger()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\log4net.cfg.xml")));
            ILog Log = LogManager.GetLogger(typeof(Logger));
            Log.Info("系统初始化Logger模块");
        }

        private ILog loger = null;
        public Logger(Type type)
        {
            loger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void Error(string msg = "出现异常", Exception ex = null)
        {
            Console.WriteLine(msg);
            loger.Error(msg, ex);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            Console.WriteLine(msg);
            loger.Warn(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            Console.WriteLine(msg);
            loger.Info(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg )
        {
            Console.WriteLine(msg);
            loger.Debug(msg);
        }
    }
}
