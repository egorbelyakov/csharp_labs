#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int main()
{
    int a,n;
    char s1[30];
    char s2[30];
    char sign;
    gets(s1);
    gets(s2);
    //2
    scanf("%d",&n);
     fflush(stdin);
    printf("%s\n",strncat(s2,s1,n));
    //4
    scanf("%d",&n);
     fflush(stdin);
    printf("%d\n",strncmp(s1,s2,n));
    //6
    scanf("%d",&n);
     fflush(stdin);
    printf("%s\n",strncpy(s1,s2,n));
    //8
    scanf("%c",&sign);
     fflush(stdin);
    char *p=strchr(s1,sign);
    printf("%d\n",(p - s1));
    //10
    char *r;
    r=strpbrk(s1,s2);
    printf("%d",r-s1+1);
    return 0;
}
