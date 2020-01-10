#include <iostream>
#include <string>
#include <hash_map>

using namespace std;
int main()
{
	int a = 4;
	string str = "ab";
	//size_t 解决机器的可移植性
	size_t size = sizeof(str);
	int str_length = int(size);
	cout << a << endl;
	cout << "str长度: " << str_length << endl;
	system("pause");
}