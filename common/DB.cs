using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace common
{
    public class DB
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection Conn()
        {
            return new SqlConnection("Server=36.7.138.114;UID=sa;PWD=Aa4008577006;database=demo;");
        }

    }
}
