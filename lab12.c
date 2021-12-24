#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[])
{
    FILE *file;
    int cnt=1;
    char arr[100];
    if(argc>0)
    {
     file=fopen(argv[1], "r");
    }
    else
    {
        printf("ERROR");
    }
    if(file==NULL)
    {
        printf("ERROR");
        return -1;
    }
    while(fgets(arr, 100, file)!=NULL)
    {
        if(cnt%2==0)
        {
          printf("%s", arr);
          cnt++;
        }
        else
        {
          cnt++;
        }
    }
    fclose(file);
    return 0;
}
