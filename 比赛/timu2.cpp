#include <iostream>
#include <string>
#include <hash_map>
/*
ʵ�ְ汾����.
*/
using namespace std;

string extract_summary(string description[], int description_len, string key_word[], int key_word_len);
int main()
{
	string desInput;//�����ַ�
	string keyWorkInput;//�ؼ���
	getline(cin, desInput);
	getline(cin, keyWorkInput);


	//�ؼ����ַ���ת��Ϊ����
	string keyWord1[100];//�ؼ���
	//int index = des112.find(" ");
	int keyWord_len = 0;
	int keyWordFirst = 0;//��ʼλ��
	while (true)
	{
		int Null = keyWorkInput.find(",");//�ҵ���һ���ո������ֵ���м�λ��
		if (Null == -1)
		{
			keyWord1[keyWord_len] = keyWorkInput;
			break;

		}

		//��ȡ��������
		keyWord1[keyWord_len] = keyWorkInput.substr(keyWordFirst, Null);
		//first = Null + 1;//��ʵλ�øı�
		keyWorkInput = keyWorkInput.substr(Null + 1, keyWorkInput.length());
		keyWord_len = keyWord_len + 1;
	}

	//string keyword[] = { "book", "knowing" };
	//����1�����ַ���ת��Ϊ�ַ�����
	//string des112 = "Life is a heavy book that is worth knowing and can't even read for a lifetime";
	//string des112 = "Life is a";


	//�����ַ���ת��Ϊ����
	string des[100];
	//int index = des112.find(" ");
	int n = 0;
	int first = 0;//��ʼλ��
	string des112 = desInput;
	while (true)
	{
		int Null = des112.find(" ");//�ҵ���һ���ո������ֵ���м�λ��
		if (Null == -1)
		{
			des[n] = des112;
			break;

		}

		//��ȡ��������
		des[n] = des112.substr(first, Null);
		//first = Null + 1;//��ʵλ�øı�
		des112 = des112.substr(Null + 1, des112.length());
		n = n + 1;
	}

	int len1 = n + 1;//��ȡָ���ַ����ĸ��������ݿո���зָ�,���ڴ�0��ʼ���������������1
	//int len2 = sizeof(keyword) / sizeof(string);
	int len2 = keyWord_len + 1;//���ڴ�0��ʼ���������������1
	//int a11 = sizeof(keyword);
	//int a22 = sizeof(string);

	string ret = extract_summary(des, len1, keyWord1, len2);
	//string ret = extract_summary(description, len1, keyword, len2);
	cout << "������Ϊ" << endl;
	cout << ret << endl;
	system("pause");

}

string extract_summary(string description[], int description_len, string key_word[], int key_word_len)
{
	int min_index_first = -1;//��¼��¼���ժҪ����ʼλ��
	int min_index_last = -1;//��¼��¼���ժҪ�Ľ���λ��
	int min_len = description_len;//��¼��¼���ժҪ�а����ַ��ĸ���
	hash_map<string, int> recorde;//��¼�ؼ�����ժҪ�г��ֵĴ���
	int count = 0;//��¼ժҪ�г����˼����ؼ���

	//��ʼ��recorde
	for (int i = 0; i < key_word_len; i++)
		recorde[key_word[i]] = 0;

	int start = 0, end = 0;
	//bool f = false;
	//����ƥ��
	while (true)
	{
		while (count < key_word_len && end < description_len)//ժҪ��δ����ȫ���Ĺؼ���
		{
			if (recorde.find(description[end]) != recorde.end())
			{
				if (recorde[description[end]] == 0)
					count++;
				recorde[description[end]]++;
			}
			end++;
		}
		while (count == key_word_len)//ժҪ�а���ȫ���ؼ���
		{
			if ((end - start) < min_len)
			{
				min_index_first = start;
				min_index_last = end - 1;
				min_len = end - start;
			}
			if (recorde.find(description[start]) != recorde.end())//description[start])�ǹؼ���
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
		tmp = tmp + " " + description[min_index_first];//ĩβ���һ���ո�
	int firstNull = tmp.find(" ");//�ҵ���һ���ո�
	tmp = tmp.substr(firstNull + 1, tmp.length());
	//����2��ȥ�����һ���ո�
	return tmp;
}