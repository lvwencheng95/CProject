#include <iostream>
#include <string>
#include <hash_map>
/*
实现版本控制.
*/
using namespace std;

string extract_summary(string description[], int description_len, string key_word[], int key_word_len);
int main()
{
	string desInput;//搜索字符
	string keyWorkInput;//关键字
	getline(cin, desInput);
	getline(cin, keyWorkInput);


	//关键字字符串转变为数组
	string keyWord1[100];//关键字
	//int index = des112.find(" ");
	int keyWord_len = 0;
	int keyWordFirst = 0;//起始位置
	while (true)
	{
		int Null = keyWorkInput.find(",");//找到第一个空格的问题值，中间位置
		if (Null == -1)
		{
			keyWord1[keyWord_len] = keyWorkInput;
			break;

		}

		//截取后面内容
		keyWord1[keyWord_len] = keyWorkInput.substr(keyWordFirst, Null);
		//first = Null + 1;//其实位置改变
		keyWorkInput = keyWorkInput.substr(Null + 1, keyWorkInput.length());
		keyWord_len = keyWord_len + 1;
	}

	//string keyword[] = { "book", "knowing" };
	//问题1：将字符串转换为字符数组
	//string des112 = "Life is a heavy book that is worth knowing and can't even read for a lifetime";
	//string des112 = "Life is a";


	//搜索字符串转变为数组
	string des[100];
	//int index = des112.find(" ");
	int n = 0;
	int first = 0;//起始位置
	string des112 = desInput;
	while (true)
	{
		int Null = des112.find(" ");//找到第一个空格的问题值，中间位置
		if (Null == -1)
		{
			des[n] = des112;
			break;

		}

		//截取后面内容
		des[n] = des112.substr(first, Null);
		//first = Null + 1;//其实位置改变
		des112 = des112.substr(Null + 1, des112.length());
		n = n + 1;
	}

	int len1 = n + 1;//获取指定字符串的个数，根据空格进行分割,由于从0开始计数，因此数量加1
	//int len2 = sizeof(keyword) / sizeof(string);
	int len2 = keyWord_len + 1;//由于从0开始计数，因此数量加1
	//int a11 = sizeof(keyword);
	//int a22 = sizeof(string);

	string ret = extract_summary(des, len1, keyWord1, len2);
	//string ret = extract_summary(description, len1, keyword, len2);
	cout << "输出结果为" << endl;
	cout << ret << endl;
	system("pause");

}

string extract_summary(string description[], int description_len, string key_word[], int key_word_len)
{
	int min_index_first = -1;//记录记录最短摘要的起始位置
	int min_index_last = -1;//记录记录最短摘要的结束位置
	int min_len = description_len;//记录记录最短摘要中包含字符的个数
	hash_map<string, int> recorde;//记录关键字在摘要中出现的次数
	int count = 0;//记录摘要中出现了几个关键字

	//初始化recorde
	for (int i = 0; i < key_word_len; i++)
		recorde[key_word[i]] = 0;

	int start = 0, end = 0;
	//bool f = false;
	//进行匹配
	while (true)
	{
		while (count < key_word_len && end < description_len)//摘要中未包含全部的关键字
		{
			if (recorde.find(description[end]) != recorde.end())
			{
				if (recorde[description[end]] == 0)
					count++;
				recorde[description[end]]++;
			}
			end++;
		}
		while (count == key_word_len)//摘要中包含全部关键字
		{
			if ((end - start) < min_len)
			{
				min_index_first = start;
				min_index_last = end - 1;
				min_len = end - start;
			}
			if (recorde.find(description[start]) != recorde.end())//description[start])是关键字
			{
				int tmp = --recorde[description[start]];
				if (tmp == 0)
					count--;
			}
			start++;
		}
		if (end >= description_len)
			break;
	}
	string tmp;
	for (; min_index_first <= min_index_last; min_index_first++)
		tmp = tmp + " " + description[min_index_first];//末尾会多一个空格
	int firstNull = tmp.find(" ");//找到第一个空格
	tmp = tmp.substr(firstNull + 1, tmp.length());
	//问题2：去除最后一个空格
	return tmp;
}