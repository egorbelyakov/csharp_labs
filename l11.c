#include<math.h>
#include "l11.h"

struct figure new_figure()
{
    struct figure Figure;
    scanf("%d %d", &Figure.x1, &Figure.y1);
    scanf("%d %d", &Figure.x2, &Figure.y2);
    scanf("%d %d", &Figure.x3, &Figure.y3);
    scanf("%d %d", &Figure.x4, &Figure.y4);
    return Figure;
};

double Plo(struct figure *F)
{
    return pow(sqrt(pow((F->x2-F->x1),2)+pow((F->y2-F->y1),2)),2);
}

double Per(struct figure *F)
{
    return sqrt(pow((F->x2-F->x1),2)+pow((F->y2-F->y1),2))*4;
}
