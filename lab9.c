#include <stdio.h>
#include <stdlib.h>

int main()
{
    const char *str[]={"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    char a[10];
    int n;
    int min, abpl, sumpl, svlimm;
    sumpl=0;
    scanf("%d %d %d", &abpl, &min, &svlimm);
    if(min>499)
       sumpl= (min-499)*svlimm+abpl;
    else
       sumpl=abpl;
    printf("%d\n", sumpl);
    scanf("%d", &n);
    printf("%s", strc

           py(a,str[n]));
    return 0;
}
