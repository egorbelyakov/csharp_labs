#include <conio.h>
#include <stdio.h>
#include<malloc.h>
int main() {
    int n;
    float A[4];
    float *p = &A;
    for(int i=0;i<4;i++)
        scanf("%f",(p+i));
    for(int i=0;i<4;i++)
    printf("%.1f\n", *(p + i));
    float *a;
    scanf("%d",&n);
    a=(float*)malloc(n*sizeof(float));
    for(int i=0;i<n;i++)
        scanf("%f",(p+i));
    for(int i=0;i<n;i++)
    printf("%.1f\n", *(p + i));
    free(a);
    return 0;
}
