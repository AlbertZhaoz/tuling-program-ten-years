using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_FiveMinutes_005_SqlSugarHelper.Models
{
    public class DbConnectModel
    {
        public DbConnectStr DbConnectStr { get; set; }
    }

    public class DbConnectStr
    {
        /// <summary>
        /// 
        /// </summary>
        public SqlServerStr SqlServerStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MySQLStr MySQLStr { get; set; }
    }

    public class SqlServerStr
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectStr { get; set; }
    }

    public class MySQLStr
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectStr { get; set; }
    }
}
