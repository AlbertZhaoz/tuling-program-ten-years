using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace NET_FiveMinutes_005_SqlSugarHelper.Interfaces
{
    public interface ISqlServerService
    {
        /// <summary>
        /// 批量创建表
        /// </summary>
        void CreateTableByModels(Assembly assembly);

        /// <summary>
        /// 直接返回数据库查询Client
        /// </summary>
        /// <returns></returns>
        SqlSugarClient GetSqlClient();

        /// <summary>
        /// 在目录下生成SqlSugar实体
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="namespaceName"></param>
        void DbFirstCreateClassFile(string directoryPath,string namespaceName);

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <returns></returns>
        List<DbTableInfo> GetTableInfoList();

        /// <summary>
        /// 获取数据库连接名称
        /// </summary>
        /// <returns></returns>
        string GetDatabaseName();

        /// <summary>
        /// 根据表名动态查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable GetTableByTableName(string tableName);

        /// <summary>
        /// 根据字典值插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dcInsert"></param>
        /// <returns></returns>
        string InsertToTable(string tableName,Dictionary<string, object> dcInsert);

        /// <summary>
        /// 根据字典更新值
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dcInsert"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        string UpdateToTable(string tableName, Dictionary<string, object> dcInsert,string columnName);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        string DeleteBatchToTable(string tableName, List<Dictionary<string, object>> list);

        /// <summary>
        /// 单条数据删除,
        /// condition格式为xxx;代表columnName = Condition
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        string DeleteSingleByIDToTable(string tableName, string columnName,string condition);

    }
}
