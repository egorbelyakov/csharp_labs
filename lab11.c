#include <stdio.h>
#include <math.h>
#include "l11.h"

int main(int argv, char ** argc)
{
    struct figure figure_=new_figure();
    struct figure **p_figure=(struct figure **)&figure_;
    //struct figure **s_figure=(struct figure **)&figure_;
    double per,plo;
    per=Per(*p_figure);
   // plo=Plo(*s_figure);
    printf("%lf ", per);
    return 0;
}
