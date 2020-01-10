using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FROM_ListView
{
    public partial class Form20190730 : Form
    {
        public Form20190730()
        {
            InitializeComponent();
        }

        #region 选中某行触发
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)//当前选中行
            {
                //以下两行代码表示的效果一样
                /*
                Console.WriteLine(this.listView1.SelectedItems[0].Text);
                Console.WriteLine(this.listView1.SelectedItems[0].SubItems[0].Text);
               */
                //调用函数，获取拼接内容
                textBox4.Text = jointContent();
               
            }
        }
        #endregion 选中某行触发

        #region 菜单中进行新增操作
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            //方法一
            //ListViewItem lvi = new ListViewItem();
            //lvi.Text = "123";
            //方法二
            //ListViewItem lvi = new ListViewItem("123");//该表示方式与上述两行达到相同的效果
            try
            {
                ListViewItem lvi = null;
                for (int i = 1; i < 6; i++)
                {
                    lvi = new ListViewItem();
                    lvi.Text = i.ToString();
                    lvi.SubItems.Add((i * 10).ToString());
                    lvi.SubItems.Add((i * 20).ToString());
                    //向当前控件中的listView中添加内容
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }
        #endregion

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)//当前选中行
            {
                //由于只能选中一行，则此处使用0即可
                MessageBox.Show(this.listView1.SelectedItems[0].Index.ToString());//获取当前索引
                this.listView1.SelectedItems[0].Remove();//进行移除
            }
            
        }

        private void 全删ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //全部移除
            listView1.Items.Clear();
            //考虑进行内存回收
        }

        #region 查询
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("当前ListView中的记录数量:" + listView1.Items.Count);
                if(""==textBoxId.Text.Trim()){//编号
                    MessageBox.Show("编号为空，请重新输入");
                }else{
                    for (int i = 0; i < listView1.Items.Count; i++)//List中项的数量
			        {
                        Console.WriteLine("i=" + i);
                        if(textBoxId.Text.Trim()==listView1.Items[i].Text)
                        {
                            string userInfo="";
                            for (int ii = 0; ii < 3; ii++)
                            {
                                Console.WriteLine("ii=" + ii);
                                switch (ii)
                                {
                                    case 0:
                                        userInfo = userInfo + "编号：" + this.listView1.Items[i].SubItems[ii].Text + ",";
                                        break;
                                    case 1:
                                        userInfo = userInfo + "姓名：" + this.listView1.Items[i].SubItems[ii].Text + ",";
                                        break;
                                    case 2:
                                        userInfo = userInfo + "省份：" + this.listView1.Items[i].SubItems[ii].Text;
                                        break;
                                    default:
                                        MessageBox.Show("无法识别！！！");
                                        break;
                                }
                            }
                        textBox4.Text =userInfo;
                        break;
                       }
                    else
                    {
                        if (i == listView1.Items.Count - 1)
                        {
                            textBox4.Text = "无满足条件记录！";
                        }
                    }
			 
			    }
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        #endregion 查询

        #region 新增
        private void button2_Click(object sender, EventArgs e)
        {
            //非空判断
            if(""==this.textBoxId.Text.Trim() || ""==this.textBoxProvince.Text.Trim() || ""==this.textBoxName.Text.Trim()){
                MessageBox.Show("存在空值，请检查!");
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = this.textBoxId.Text.Trim();//编号
                lvi.SubItems.Add(this.textBoxName.Text.Trim());
                lvi.SubItems.Add(this.textBoxProvince.Text.Trim());
                //向当前控件中的listView中添加内容
                listView1.Items.Add(lvi);

                //进行提示
                textBox4.Text = "新增成功！" + "编号：" + this.textBoxId.Text.Trim() + "，姓名：" + this.textBoxProvince.Text.Trim() + "，身份：" + this.textBoxName.Text.Trim();
            }
           

        }
        #endregion 新增

        #region 删除
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("当前ListView中的记录数量:" + listView1.Items.Count);
                if ("" == textBoxId.Text.Trim())
                {//编号
                    MessageBox.Show("编号为空，请重新输入");
                }
                else
                {
                    for (int i = 0; i < listView1.Items.Count; i++)//List中项的数量
                    {
                        Console.WriteLine("i=" + i);
                        if (textBoxId.Text.Trim() == listView1.Items[i].Text)
                        {
                            string userInfo = "";
                            for (int ii = 0; ii < 3; ii++)
                            {
                                Console.WriteLine("ii=" + ii);
                                switch (ii)
                                {
                                    case 0:
                                        userInfo = userInfo + "删除成功！编号：" + this.listView1.Items[i].SubItems[ii].Text + ",";
                                        break;
                                    case 1:
                                        userInfo = userInfo + "姓名：" + this.listView1.Items[i].SubItems[ii].Text + ",";
                                        break;
                                    case 2:
                                        userInfo = userInfo + "省份：" + this.listView1.Items[i].SubItems[ii].Text;
                                        break;
                                    default:
                                        MessageBox.Show("无法识别！！！");
                                        break;
                                }
                            }
                            this.listView1.Items[i].Remove();
                            textBox4.Text = userInfo;
                            break;
                        }
                        else
                        {
                            if (i == listView1.Items.Count - 1)
                            {
                                textBox4.Text = "无满足条件记录！";
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        #endregion 删除

        #region 自定义方法：拼接查询内容
        private string jointContent(){
            string userInfo = "";
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(this.listView1.SelectedItems[0].SubItems[i].Text);
                switch (i)
                {
                    case 0:
                        userInfo = userInfo + "编号：" + this.listView1.SelectedItems[0].SubItems[i].Text + ",";
                        break;
                    case 1:
                        userInfo = userInfo + "姓名：" + this.listView1.SelectedItems[0].SubItems[i].Text + ",";
                        break;
                    case 2:
                        userInfo = userInfo + "省份：" + this.listView1.SelectedItems[0].SubItems[i].Text;
                        break;
                    default:
                        MessageBox.Show("无法识别！！！");
                        break;
                }
            }
            return userInfo;
        }                               
        #endregion

        #region 清空查询区域
        private void button4_Click(object sender, EventArgs e)
        {
            this.textBoxId.Text = "";
            this.textBoxProvince.Text = "";
            this.textBoxName.Text = "";
        }
        #endregion 清空查询区域
    }
}
