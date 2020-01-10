using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBasicControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt= this.dateTimePicker.Value;
            this.textBox_showTime.Text = dt.ToString();
        }

        #region 选中节点触发
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //获取当前树中的记录数
            //this.textBox1.Text = this.treeView.GetNodeCount(true).ToString();
            //获取当前树节点的描述内容
            this.textBox1.Text = treeView.SelectedNode.Text;
        }
        #endregion 选中节点触发
    }
}
