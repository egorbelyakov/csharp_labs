#ifndef L11_H
#define L11_H

struct figure
{
    int x1,y1;
    int x2,y2;
    int x3,y3;
    int x4,y4;
};

struct figure new_figure();
double Per(struct figure *p_fig);
double Plo(struct figure *s_fig);
#endif //L11_H
