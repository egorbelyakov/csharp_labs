#include <stdio.h>
#include <stdlib.h>
#include<math.h>

typedef unsigned int ui;

enum months{
January,
February,
March,
April,
May,
June,
July,
August,
September,
October,
November,
December,
};

int main()
{
    enum months July;
    printf("%d\n",July);
    for(int i=0;i<30;i++)
    printf("_");
    printf("\n");

    struct parameters
    {
        int x1,y1,x2,y2,x3,y3,x4,y4;
        int s;
    };

    struct parameters A;
    printf("Input x & y for 4 points\n");
        scanf("%d %d %d %d %d %d %d %d",&A.x1, &A.y1,&A.x2, &A.y2,&A.x3, &A.y3,&A.x4, &A.y4);
    float d1=sqrt(pow((A.x2-A.x1),2)+pow((A.y2-A.y1),2));
    float d2=sqrt(pow((A.x3-A.x1),2)+pow((A.y3-A.y1),2));
    A.s=d1*d2;
    printf("Ploshad = %d\n",A.s);

    struct bitfieald
    {
        ui Ready : 1;
        ui LowToner : 1;
        ui DamagedReel : 1;
        ui NoPaper : 1;
    };

    union un
    {
        struct bitfieald bitf;
        ui i;
    };
    union un u;
    scanf("%x", &u.i);
    printf("Ready %s\n",(u.bitf.Ready==1)?"On":"Off");
    printf("Low toner %s\n",(u.bitf.LowToner==1)?"On":"Off");
    printf("Damaged reel %s\n",(u.bitf.DamagedReel==1)?"On":"Off");
    printf("No paper %s\n",(u.bitf.NoPaper==1)?"On":"Off");
    return 0;
}
