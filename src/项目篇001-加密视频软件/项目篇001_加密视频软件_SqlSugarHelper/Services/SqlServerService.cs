using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Options;
using NET_FiveMinutes_005_SqlSugarHelper.Interfaces;
using NET_FiveMinutes_005_SqlSugarHelper.Models;
using SqlSugar;

namespace NET_FiveMinutes_005_SqlSugarHelper.Services
{
    public class SqlServerService:ISqlServerService
    {
        private readonly SqlSugarClient _sqlClient;
        private readonly IOptionsSnapshot<DbConnectModel> _DbConnecOptions; //依赖注入可选项

        public SqlServerService(IOptionsSnapshot<DbConnectModel> dbConnecOptions)
        {
            this._DbConnecOptions = dbConnecOptions;
            if (_DbConnecOptions != null)
            {
                // 主配置数据库
                _sqlClient = new SqlSugarClient(new ConnectionConfig()
                {              
                    ConnectionString = _DbConnecOptions.Value.DbConnectStr.SqlServerStr.ConnectStr,
                    DbType = SqlSugar.DbType.SqlServer,
                    IsAutoCloseConnection = true
                });

                // 如果不存在则创建数据库,此方法无法用于远程连接
                // 远程连接需要的权限较高，只有在本地连接数据库的时候启用数据库自动创建功能
                if(_DbConnecOptions.Value.DbConnectStr.SqlServerStr.ConnectStr.Split(';').First(a => a.Contains("Server"))==".")
                {
                    _sqlClient.DbMaintenance.CreateDatabase();
                }
            }
        }

        /// <summary>
        /// 批量创建表
        /// 如果查询数据库表的数量为0，则检索 Models 文件夹下面所有的类，创建表
        /// </summary>
        public void CreateTableByModels(Assembly assembly)
        {
            var tableInfoList = _sqlClient.DbMaintenance.GetTableInfoList(false);

            if(tableInfoList.Count<=0)
            {
                // 命名空间过滤，不包含配置实体
                //var types = Assembly.GetExecutingAssembly().GetTypes()
                //    .Where(it => it.FullName.Contains("Models")&&(!it.FullName.Contains("DbConnectModel")))
                //    .ToArray();
                var types = assembly.GetTypes()
                    .Where(it => it.FullName.Contains("Models")&&(!it.FullName.Contains("DbConnectModel")))
                    .ToArray();
                //调试SQL事件，可以删掉 (要放在执行方法之前)
                //_sqlClient.Aop.OnLogExecuting = (sql, pars) =>
                //{
                //    var test = sql;           
                //};
                // 根据types创建表
                _sqlClient.CodeFirst.SetStringDefaultLength(200).InitTables(types);
            }
        }

        /// <summary>
        /// 直接返回数据库查询Client
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetSqlClient()
        {
            return _sqlClient;
        }

        /// <summary>
        /// 在目录下生成SqlSugar实体
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="namespaceName"></param>
        public void DbFirstCreateClassFile(string directoryPath,string namespaceName)
        {
            _sqlClient.DbFirst.CreateClassFile(directoryPath, namespaceName);        
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetTableInfoList()
        {
            return _sqlClient.DbMaintenance.GetTableInfoList(false);
        }

        /// <summary>
        /// 获取数据库连接名称
        /// </summary>
        /// <returns></returns>
        public string GetDatabaseName()
        {
            return _DbConnecOptions.Value.DbConnectStr.SqlServerStr.ConnectStr.Split(';').First(a => a.Contains("Database"));
        }

        /// <summary>
        /// 根据表名动态查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableByTableName(string tableName)
        {
            // 根据表名动态查询
            return _sqlClient.Queryable<dynamic>().AS(tableName: tableName).ToDataTable();
        }

        /// <summary>
        /// 根据字典值插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dcInsert"></param>
        /// <returns></returns>
        public string InsertToTable(string tableName,Dictionary<string, object> dcInsert)
        {
            try
            {
                _sqlClient.Insertable(dcInsert).AS(tableName: tableName).ExecuteCommand();
                return "Insert Successfully";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }        
        }

        /// <summary>
        /// 根据字典更新值
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dcInsert"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string UpdateToTable(string tableName, Dictionary<string, object> dcInsert,string columnName)
        {
            try
            {
                _sqlClient.Updateable(dcInsert).AS(tableName).WhereColumns(columnName).ExecuteCommand();
                return "Update Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string DeleteBatchToTable(string tableName, List<Dictionary<string, object>> list)
        {
            try
            {
                _sqlClient.Deleteable<object>().AS(tableName).WhereColumns(list).ExecuteCommand();
                return "DeleteBatch Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        /// <summary>
        /// 单条数据删除,
        /// condition格式为xxx;代表columnName = Condition
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string DeleteSingleByIDToTable(string tableName, string columnName,string condition)
        {
            try
            {
                var whereString = $"{columnName}=@{columnName}";
                var obj = new { ID = $"{condition}" };
                _sqlClient.Deleteable<object>().AS(tableName).Where(whereString,obj).ExecuteCommand();
                return "DeleteSingle Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
