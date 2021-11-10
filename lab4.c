#include <stdio.h>
#include <stdlib.h>

int main()
{
int a,b,c,z;
scanf("%d",&c);
z=(c<=100 && c>=1)?1:0;
printf("1-popadaet\n0-ne popadaet\n%d",z);
scanf("%d",&a);
    printf("%d",a&(1<<3)!=0);
    return 0;
}
