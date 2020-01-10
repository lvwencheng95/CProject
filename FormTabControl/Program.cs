using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FormTabControl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            /*
            //一、DataSet的使用
            DataSet ds = new DataSet();
            //1、获取去DataSet中第一个表中第一行第一列中的值，可设置为i,j
            //方式一
            Object obj1= ds.Tables[0].Rows[0][0];
            //方式二
            Object obj2 = ds.Tables[0].Rows[0].ItemArray[0];
            //2、获取第一个表中的列数
            int num1= ds.Tables[0].Columns.Count;
            //3、获取第一个表中的行数
            int num2 = ds.Tables[0].Rows.Count;
            //4、获取第一个表中第一列的列名
            string str1 = ds.Tables[0].Columns[0].ToString();
            //5、向DateSet中添加指定DataTable
            DataTable dt2 = new DataTable();
            ds.Tables.Add(dt2);

            //二、DataTable的使用
            //1、创建一个DataTable
            //不带名称
            DataTable dt = new DataTable();
            //带名称
            DataTable dt1 = new DataTable("tb1");

            //2、向DataTable中添加列,包含名称以及类型
            dt.Columns.Add("name",System.Type.GetType("System.String"));


            //三、DataRows的使用
            //1、定义一个DataRows
            DataRow dr = new DataRow();
            //向DataRow中添加列以及对应值
            dr["name"] = "123";//自动根据设置值，判单其类型，字符
            dr["pwd"] = "root";
            dr["isValide"] = true;//布尔类型
            //2、向DataTable中加入DataRows
            dt.Rows.Add(dr);

            //3、对DataTable中的DataRows赋值
            //方式1
            DataRow dr1 = dt.Rows[0];
            dr1[0] = "123";
            dr1[1] = "root";
            dr1[2] = true;
            //方式2
            dr1["name"] = "1231";
            dr1["pwd"] = "root1";
            dr1["isValide"] = true;
            //方式3
            dt.Rows[0][0] = "1232";
            dt.Rows[0][1] = "root2";
            dt.Rows[0][2] = false;
            //方式4
            dt.Rows[0]["name"] = "1232";
            dt.Rows[0]["pwd"] = "root2";
            dt.Rows[0]["isValide"] = false;
            */
            string constructorString = "server=127.0.0.1;port=3306;user=root;password=123456; database=sql_learn;";
            MySqlConnection myConnect=null;
            MySqlCommand myCmd = null;
            try
            {
                myConnect = new MySqlConnection(constructorString);
                myConnect.Open();
                myCmd = new MySqlCommand("INSERT into t_logininfo(carUserId,carUserName) VALUES('12','2');", myConnect);
                if (myCmd.ExecuteNonQuery()>0)
                {
                    Console.WriteLine("数据插入成功");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
              
            myCmd.Dispose();
            myConnect.Close();

        }
    }
}
