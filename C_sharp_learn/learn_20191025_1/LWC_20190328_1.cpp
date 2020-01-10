#include<iostream>
#include<cstdlib>
#include<string>
using namespace std;

//（1）
//使用指针，对两个数做交换操作，理解地址运算符与间接运算符的区别
void interChange(int * a, int * b){
	//使用*a表示获取地址名对应的值
	int temp = *a;
	*a = *b;
	*b = temp;
}

//（2）
//测试字符串
int test_20190530()
{
	printf("%s,%p,%c\n", "We", "are", *"space farers");
	return 0;
}

//（3）
//实现两个数据的交换
int test_20190528()
{
	//对两个数进行交换操作
	int x = 3, y = 4;
	//使用&表示获取地址名称，下面调用的方法，传入的参数是地址名
	interChange(&x, &y);
	cout << x << y << endl;
	return 0;
}
/*
在同一个源文件夹中，只能存在一个main函数(主函数)，若定义两个编译会提示错误。这个不像Java可以在多个类中定义。
*/
int main()
{
	//（3）交换两数
	//test_20190528();//函数的定义还必须在main函数之前，否则无法识别该函数名

	//测试字符串
	test_20190530();
	system("pause");
}