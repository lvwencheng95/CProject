#include<iostream>
#include<cstdlib>
#include<string>
using namespace std;

//��1��
//ʹ��ָ�룬������������������������ַ��������������������
void interChange(int * a, int * b){
	//ʹ��*a��ʾ��ȡ��ַ����Ӧ��ֵ
	int temp = *a;
	*a = *b;
	*b = temp;
}

//��2��
//�����ַ���
int test_20190530()
{
	printf("%s,%p,%c\n", "We", "are", *"space farers");
	return 0;
}

//��3��
//ʵ���������ݵĽ���
int test_20190528()
{
	//�����������н�������
	int x = 3, y = 4;
	//ʹ��&��ʾ��ȡ��ַ���ƣ�������õķ���������Ĳ����ǵ�ַ��
	interChange(&x, &y);
	cout << x << y << endl;
	return 0;
}
/*
��ͬһ��Դ�ļ����У�ֻ�ܴ���һ��main����(������)�������������������ʾ�����������Java�����ڶ�����ж��塣
*/
int main()
{
	//��3����������
	//test_20190528();//�����Ķ��廹������main����֮ǰ�������޷�ʶ��ú�����

	//�����ַ���
	test_20190530();
	system("pause");
}