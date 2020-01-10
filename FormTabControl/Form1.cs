using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormTabControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取当前输入的内容
            string inputContext = this.textBoxSelect.Text;
            //Console.WriteLine(this.tabControl1.TabIndex);         

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            //if使用次数多了，感觉还是使用switch比较自然，后续代码可尝试不同的实现方式
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    this.textBox1.Text = inputContext;
                    break;
                case 1:
                    this.textBox2.Text = inputContext;
                    break;
                case 2:
                    this.textBox3.Text = inputContext;
                    break;
                default:
                    MessageBox.Show("无法识别！");
                    break;
            }
        }

        #region 选项卡索引值改变
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前输入的内容
            string inputContext = this.textBoxSelect.Text;
            //Console.WriteLine(this.tabControl1.TabIndex);         

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    this.textBox1.Text = inputContext;
                    break;
                case 1:
                    this.textBox2.Text = inputContext;
                    break;
                case 2:
                    this.textBox3.Text = inputContext;
                    break;
                default:
                    MessageBox.Show("无法识别！");
                    break;
            }
        }
        #endregion 选项卡索引值改变

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("fsadf");
        }

        //sender事件中传入的参数，表示触发事件的控件，比如这个事件按钮触发，则可获取该按钮的信息
        //e事件传入的第二个参数，表示当前事件类型，控件的位置信息等内容
        private void btn1_Click(object sender, EventArgs e)
        {
            //判断当前控件背景颜色值
           //C#中数组使用int[] arr的方式
            int[] arr = { -16711872,-16842752,-32513,-32640,-4144960,-8355648,-8355712 };
            //int []arr1 ={123,34};
            /*
            for (int i = 0; i < arr.Length; i++)
            {
                button1.BackColor = Color.FromArgb(arr[i]);
                Console.WriteLine(arr[i] + "  "+ button1.BackColor.ToString());
            }
            */
            Button btnTemp = (Button)sender;
            //进行以下练习主要为了动态获取控件内容
            int num = this.p_bottom.Controls.Count;
            foreach (var item in this.p_bottom.Controls)
            {
                
                Console.WriteLine(item.GetType().ToString());
                //代码还是练习，而不是说看一遍视频就行   20190808
                if (item.GetType().ToString().Equals("System.Windows.Forms.Button"))
                {
                    //btnTemp = (Button)item;
                    //Console.WriteLine(btnTemp.Text);

                }
            }
            //this.panel.Visible = false;
            //this.panel2.Visible = false;
            //this.panel3.Visible = false;
            switch (btnTemp.Name)
            {
                case "btn1":
                    this.panel.Controls.Add(this.panel1);
                    this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
                    //this.panel.Visible = true;
                    break;
                case "btn2":
                    this.panel.Controls.Add(this.panel2);
                    this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                    //this.panel2.Visible = true;
                    break;
                case "btn3":
                    this.panel.Controls.Add(this.panel3);
                    this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
                    //this.panel3.Visible = true;
                    break;
                default:
                    break;
            }
            //sender事件中传入的参数，表示触发事件的控件，比如这个事件按钮触发，则可获取该按钮的信息
            Button btn123 = (Button)sender;

            Console.WriteLine("------------," + btn123.Text+"------------," +btn123.Name);
            //e事件传入的第二个参数，表示当前事件类型，控件的位置信息等内容
            Console.WriteLine(e.ToString());//输出当前操作为点击事件，debug状态可查看对应的坐标位置等信息
            }
    }
}
