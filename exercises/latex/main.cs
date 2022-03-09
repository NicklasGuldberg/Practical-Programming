using System;
using static System.Math;
using static System.Console;

class main{
    static double ex(double x){
        if(x<0)return 1/ex(-x);
        if(x>1.0/8)return Pow(ex(x/2),2); // explain this
        return 1+x*(1+x/2*(1+x/3*(1+x/4*(1+x/5*(1+x/6*(1+x/7*(1+x/8*(1+x/9*(1+x/10)))))))));
    }
    static void Main(){
        for(double x = -100; x<100; x+=5){
            WriteLine($"{x}, {ex(x)}");
        }
    }
}