using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace MusicPlayer
{
    public partial class FormMusic : Form
    {
        //存放歌曲的路径，每次切歌时获取
        private List<string> urlList = new List<string>();

        //每次添加歌曲的路径，用于往xml文件中写入数据
        private List<string> addSongsList = new List<string>();

        private double timeMax, timeMin;//歌曲的时长

        private RWXml rwXml = new RWXml();//读写xml文件，将添加歌曲的路径写进xml文件

        public FormMusic()
        {
            InitializeComponent();

            List<string> loadSongs = rwXml.readXmL();
            if (loadSongs != null)
            {
                //将歌曲添加到列表中
                foreach (string url in loadSongs)
                {
                    Console.WriteLine(url);
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(url));
                    urlList.Add(url);//切歌时会使用
                }
            }
        }

        #region 添加歌曲

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Title = "请选择音乐文件";
            of.Filter = "(*.mp3)|*.mp3";
            if (of.ShowDialog() == DialogResult.OK)
            {
                //把用户选择的文件存储到数组中
                //string[] nameList = of.SafeFileNames;
                string[] nameList = of.FileNames;
                foreach (string url in nameList)
                {
                    Console.WriteLine(url);
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(url));
                    urlList.Add(url);
                    addSongsList.Add(url);
                }
                if (addSongsList != null)
                {
                    //添加歌曲同时往XML文件中写入数据
                    rwXml.addXml(addSongsList);
                    //清理，否则再次添加歌曲会再次添加上次的歌曲
                    addSongsList.Clear();
                }
            }
            //of.ShowDialog();
        }

        #endregion 添加歌曲

        #region 播放

        private void btnListen_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(timer1.Enabled);
            //Console.WriteLine(axWindowsMediaPlayer1.playState);
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPaused)
            {
                //1、暂停后播放
                axWindowsMediaPlayer1.Ctlcontrols.play();
                timer1.Enabled = true;//设置为true后，能根据触发进度条事件
            }
            else
            {
                //2、选中歌曲，点击播放
                //未选择，索引值返回-1
                int songsIndex = listBox1.SelectedIndex < 0 ? 0 : listBox1.SelectedIndex;
                listBox1.SelectedIndex = songsIndex;
                axWindowsMediaPlayer1.URL = urlList[songsIndex];
                label1.Text = listBox1.SelectedItem.ToString();
                timer1.Enabled = true;

            }
        }

        #endregion 播放

        #region 暂停

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        #endregion 暂停

        #region 停止

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        #endregion 停止

        #region 上一首

        private void btnPre_Click(object sender, EventArgs e)
        {
            //获取当前列表中的数量
            Console.WriteLine(listBox1.Items.Count);
            int n = listBox1.SelectedIndex - 1;
            n = n < 0 ? 0 : n;//防止越界
            listBox1.SelectedIndex = n;
            axWindowsMediaPlayer1.URL = urlList[n];
            label1.Text = listBox1.SelectedItem.ToString();
        }

        #endregion 上一首

        #region 下一首

        private void btnNext_Click(object sender, EventArgs e)
        {
            int n = listBox1.SelectedIndex + 1;
            n = n >= listBox1.Items.Count - 1 ? listBox1.Items.Count - 1 : n;
            listBox1.SelectedIndex = n;
            axWindowsMediaPlayer1.URL = urlList[n];
            label1.Text = listBox1.SelectedItem.ToString();
        }

        #endregion 下一首

        #region 列表发生变化，播放音乐

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前歌曲的索引号
            int n = listBox1.SelectedIndex < 0 ? 0 : listBox1.SelectedIndex;
            axWindowsMediaPlayer1.URL = urlList[n];
            label1.Text = listBox1.SelectedItem.ToString();
            timer1.Enabled = true;
        }

        #endregion 列表发生变化时，播放音乐

        #region 进度条

        private void timer1_Tick(object sender, EventArgs e)
        {
            //获取文件的总时长
            timeMax = axWindowsMediaPlayer1.currentMedia.duration;
            //
            timeMin = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            Console.WriteLine("[" + timeMax + "," + timeMin + "]");
            trackBar1.Maximum = (int)(timeMax);
            trackBar1.Value = (int)(timeMin);

            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsStopped)
            {
                trackBar1.Value = 0;
                timer1.Enabled = false;
            }

        }

        #endregion 进度条

        #region 鼠标按下

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        #endregion 鼠标按下

        #region 鼠标释放

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            double timeCurrent = trackBar1.Value;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = timeCurrent;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timer1.Enabled = true;
        }

        #endregion 鼠标释放
    }
}