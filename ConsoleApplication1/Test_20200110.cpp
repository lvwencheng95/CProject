#include <iostream>
#include <string>
#include <hash_map>

using namespace std;
int main()
{
	int a = 4;
	string str = "ab";
	//size_t ��������Ŀ���ֲ��
	size_t size = sizeof(str);
	int str_length = int(size);
	cout << a << endl;
	cout << "str����: " << str_length << endl;
	system("pause");
}