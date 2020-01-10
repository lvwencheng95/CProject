using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTest_20190812;
using System.Text.RegularExpressions;

namespace CodeTest_20190812
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------------------
            //--------------------------------------------------------------------------
            //对于字符串的操作，可查看String类，该类中详细介绍了包含的方法以及如何进行使用。
            //--------------------------------------------------------------------------
            //--------------------------------------------------------------------------
            //1、字符串拼接
            //--------------------------------------------------------------------------
            //使用+
            Stopwatch sw = new Stopwatch();
            sw.Start();//开始计时
            string str1 = "使用+进行字符串拼接0";
            for (int i = 1; i <= 100; i++)//测试发现循环100000次，花费10912ms
            {
                str1 = str1 + "+" + i;
            }
            long times1 = sw.ElapsedMilliseconds;
            sw.Stop();
            Console.WriteLine(times1);
            //Console.WriteLine(str1);
            //使用stringBuilder
            string str2 = "使用+进行字符串拼接0";
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            sb.Append(str2);
            for (int j = 1; j <= 100; j++)//测试发现循环100000次，花费12ms.当拼接内容以及次数较多，使用StringBuilder
            {
                sb.Append("+");
                sb.Append(j.ToString());
            }
            long times2 = sw.ElapsedMilliseconds;
            sw.Stop();
            Console.WriteLine(times2);
            //Console.WriteLine(sb.ToString());
            //--------------------------------------------------------------------------
            //2、字符串修改
            //--------------------------------------------------------------------------
            //对于定义的字符串前缀带有@，表示后面内容为字符串，不需转义
            //string strTest = @"D:/123/456.tex";
            string strReplace="今天晴天";
            strReplace = strReplace.Replace("晴天","雨天");
            Console.WriteLine(strReplace);
            //--------------------------------------------------------------------------
            //3、字符串比较
            //--------------------------------------------------------------------------
            string strA = "123";
            string strB = "234";
            Console.WriteLine("使用Equals方式："+strA.Equals(strB));
            Console.WriteLine(""+String.Compare(strA,strB));//不为0表示两个字符串不相等

            //--------------------------------------------------------------------------
            //4、字符串的拆分
            //--------------------------------------------------------------------------
            Console.WriteLine("字符串的拆分");
            char[] spliterChar = {' ',',','.'};
            string oneWord = "wo shi zhong guo ren,wo shen shen de ai zhe wo de zu guo.123";
            string[] word = oneWord.Split(spliterChar);
            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine("字符串i="+i+",值："+word[i]);
            }
            //--------------------------------------------------------------------------
            //5、字符串的搜索
            //--------------------------------------------------------------------------
            Console.WriteLine("字符串的搜索");
            string testString = "abc1231423525";
            string beginString = "abc";
            Console.WriteLine("1:"+testString.StartsWith(beginString));//返回布尔类型
            string beginAString = "aBc";
            Console.WriteLine("2:" + testString.StartsWith(beginAString, StringComparison.CurrentCultureIgnoreCase));
            string abcEmpty = " ";
            //不要搞混了，oracle中不能使用这种方式判断空格
            if (""==abcEmpty.Trim())//可以判断空格
            {
                Console.WriteLine("abcEmpty为空");
            }
            //--------------------------------------------------------------------------
            //6、字符串的搜索
            //--------------------------------------------------------------------------
            Console.WriteLine("使用正则表达式搜索字符串");
            string[] sentences = { "cow over the moon", "Betsy the Cow", "cowering in the corner", "no match here" };
            string sPattern = "cow";

            foreach (string s in sentences)
            {
                System.Console.Write("{0,24}", s);
                //Regex在命名空间using System.Text.RegularExpressions;里
                if (Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("  (match for '{0}' found)", sPattern);
                }
                else
                {
                    System.Console.WriteLine();
                }
            }
        }
    }
}
