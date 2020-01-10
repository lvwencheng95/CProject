using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MsdnMysqlHelper
{
    class MysqlHelper
    {
        private string strConn = string.Empty;

         public MysqlHelper(string conn)
        {
            strConn = conn;
        }
        public MysqlHelper()
        {
            strConn = string.Format("server=127.0.0.1;port=3306;user=root;password=123456; database=sql_learn;");
        }

        #region  执行Sql语句，增删改
        /// <summary>
        /// 执行Sql语句，增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(string sql, params MySqlParameter[] parms)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        if (parms != null)
                        {
                            cmd.Parameters.AddRange(parms);
                        }
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return 0;
                    }

                }
            }
        }
        #endregion

        #region 执行Sql语句，1个返回值
        /// <summary>
        /// 执行一个Sql语句，1个返回值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">sql参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params MySqlParameter[] parms)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parms != null)
                    {
                        cmd.Parameters.AddRange(parms);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        #endregion

        #region 执行sql语句，返回结果集
        public MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] parms)
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                if (parms != null)
                {
                    cmd.Parameters.AddRange(parms);
                }
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        #endregion
    }
}
