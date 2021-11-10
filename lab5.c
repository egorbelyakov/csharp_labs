#include<stdlib.h>
#include <stdio.h>
int main()
{
    int i,j,k;
int A[6]={23,5678,2,564,77,443};
for(i =0;i<6;i++)
printf("%d ",A[i]);
printf("\n");
int B[2][2]=
{
    {1,0},
    {1,4}
};
int C[2][2]=
{
    {1,2},
    {0,1}
};
int R[2][2];
for(i=0;i<2;i++)
    for(j=0;j<2;j++)
{
    R[i][j]=0;
    for(k=0;k<2;k++)
        R[i][j]+=B[i][k]*C[k][j];
}
    for(int i=0;i<2;i++){
        for(int j=0;j<2;j++){
        printf("%2d",R[i][j]);
        }
        printf("\n");
    }
return 0;
}





