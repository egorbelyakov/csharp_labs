#include<stdlib.h>
#include<stdio.h>
#include<math.h>
int main()
{
	int a,b;
	scanf("%d",&a);
	printf("%o\n",a);
	printf("%x %d\n",a, a << 2);
	printf("%x %d\n",a,~a);
	scanf("%x",&b);
	printf("%x",b | a);
	return 0;
}
