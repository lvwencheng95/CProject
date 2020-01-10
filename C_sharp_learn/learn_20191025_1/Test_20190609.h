#include<stdio.h>
int main(void){
	const char * msg = "I am chinese!";
	//const char * copy = msg;
	const char * copy;
	copy = msg;
	printf("s%\n", copy);
	printf("msg=s%; &msg=p%; value=%p\n", msg, &msg, msg);
	//printf();
}