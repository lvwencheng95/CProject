using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsdnMysqlHelper;
using MySql.Data.MySqlClient;

namespace carHome
{
    public partial class FrmRegist : Form
    {
        public FrmRegist()
        {
            InitializeComponent();
        }
        MysqlHelper sqlhelper;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = this.textBox_userName.Text;
                string pwd = this.textBox_pwd.Text;
                string acPwd = this.textBox_acPwd.Text;
                if (userName.Trim().Equals("") || pwd.Trim().Equals("") || acPwd.Trim().Equals(""))
                {
                    MessageBox.Show("请填写完整，存在空值！");
                }
                if (!pwd.Trim().Equals(acPwd.Trim()))
                {
                    MessageBox.Show("两次输入密码不一致");
                }
                else
                {
                    string sql = "INSERT INTO t_logininfo (carUserId,carUserName) VALUES (@userName, @pwd);";

                    MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@userName",userName),
                 new MySqlParameter("@pwd",pwd)
                };

                    //会造成Sql注入
                    int res = sqlhelper.ExecuteNonQuery(sql, param);
                    if (res > 0)
                    {
                        MessageBox.Show("恭喜  [ " + userName + " ] 注册成功");
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("[ " + userName + " ] 注册失败");
                    }
                }

            }
            catch (Exception ex1)
            {

                Console.WriteLine(ex1.Message);
            }
        }

        private void FrmRegist_Load(object sender, EventArgs e)
        {
            sqlhelper = new MysqlHelper(); //数据库连接
        }
    }
}
