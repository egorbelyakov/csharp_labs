#include<stdlib.h>
#include<stdio.h>
#include<math.h>
int main()
{
	double z1,z2;
	int a;
	const double pi=3.1415926;
	scanf("%d",&a);
	z1=cos(a)+sin(a)+cos(3*a)+sin(3*a);
	z2=2*sqrt(2)*cos(a)*sin((pi/4)+2*a);

	printf("z1= %f\nz2= %f",z1,z2);
	return 0;
}
