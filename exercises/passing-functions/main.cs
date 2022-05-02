using System;
using static System.Console;
using static System.Math;
using static table;
class main{
    static void Main(){
        double a = 0;
        double b = 2*PI;
        double dx = 0.5;
        double k = 0;
        System.Func<double,double> f = delegate(double x){return Sin(k*x);};
        for (int i=1; i<=3; i++){
            k = i;
            WriteLine("----------------------------");
            WriteLine($"Table of f(x) = sin({k}*x)");
            WriteLine("x  |  f(x)");
            make_table(f,a,b,dx);
        } 
    }
}