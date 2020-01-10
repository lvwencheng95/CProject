using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Xml;

namespace MusicPlayer
{
    public class RWXml
    {
        #region 往XML中写数据

        public void writeXml()
        {
            //测试用例
            /*
            XmlDocument xDoc = new XmlDocument();
            XmlDeclaration declaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            xDoc.AppendChild(declaration);
            //根元素
            XmlElement elemRoot = xDoc.CreateElement("songs");
            xDoc.AppendChild(elemRoot);
            //xDoc.Save("songs.xml");

            //添加子节点
            XmlElement elemChild = xDoc.CreateElement("song");
            //添加属性
            elemChild.SetAttribute("url", "123");

            //xDoc.AppendChild(elemChild);
            elemRoot.AppendChild(elemChild);
            xDoc.Save("D:/myCodeTest/lvwenchengTest/FORM1/songs.xml");
            */

            XmlDocument xDoc = new XmlDocument();
            XmlDeclaration declaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            xDoc.AppendChild(declaration);
            //根元素
            XmlElement elemRoot = xDoc.CreateElement("songs");
            elemRoot.SetAttribute("number", "0");
            xDoc.AppendChild(elemRoot);
            xDoc.Save("D:/myCodeTest/lvwenchengTest/FORM1/songs.xml");
        }

        #endregion 往XML中写数据

        #region 读取XML中的数据

        public List<string> readXmL()
        {
            List<string> songsList = new List<string>();
            XmlDocument doc = new XmlDocument();
            string path = "D:/myCodeTest/lvwenchengTest/FORM1/songs.xml";
            try
            {
                doc.Load(path);//加载xml文件
            }
            catch (Exception e)
            {
                writeXml();
                Console.WriteLine(e.Message);
            }
            finally
            {
                doc.Load(path);//加载xml文件
            }
            //XmlNodeList rootNode = doc.DocumentElement.ChildNodes;//根节点
            XmlElement songsElement = doc.DocumentElement;//获取根节点,XmlElement继承自XmlNode类
            Console.WriteLine(songsElement.Attributes["number"].Value);//获取歌曲总记录
            int songsNum = Convert.ToInt32(songsElement.Attributes["number"].Value);
            if (songsNum == 0)
            {
                return null;
            }
            //获取歌曲的具体路径
            XmlNodeList songNodelist = songsElement.ChildNodes;//子节点
            foreach (XmlNode songNode in songNodelist)
            {
                string song = songNode.Attributes["url"].Value;
                Console.WriteLine(song);
                songsList.Add(song);
            }
            return songsList;
        }

        #endregion 读取XML中的数据

        #region 往XML中新增歌曲

        public void addXml(List<string> songsList)
        {
            XmlDocument xDoc = new XmlDocument();
            string path = "D:/myCodeTest/lvwenchengTest/FORM1/songs.xml";
            try
            {
                xDoc.Load(path);//加载xml文件
            }
            catch (Exception e)
            {
                writeXml();
                Console.WriteLine(e.Message);
            }
            finally
            {
                xDoc.Load(path);//加载xml文件
            }
            //获取根元素
            XmlElement elemRoot = xDoc.DocumentElement;
            Console.WriteLine(elemRoot.Attributes["number"].Value);
            //获取当前歌曲数量
            int songsNum = Convert.ToInt32(elemRoot.Attributes["number"].Value);
            int songsNumCurrent = songsNum + songsList.Count();//已有歌曲加当前新加歌曲
            elemRoot.SetAttribute("number", songsNumCurrent.ToString());

            foreach (string songUrl in songsList)
            {
                //添加子节点
                XmlElement elemChild = xDoc.CreateElement("song");
                //添加属性
                elemChild.SetAttribute("url", songUrl);
                elemRoot.AppendChild(elemChild);
            }
            //保存数据
            xDoc.Save("D:/myCodeTest/lvwenchengTest/FORM1/songs.xml");
        }

        #endregion 往XML中新增歌曲
    }
}