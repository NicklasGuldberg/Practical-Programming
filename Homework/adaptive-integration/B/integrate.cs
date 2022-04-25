using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public static class quad{
    public static double integrate(
        Func<double,double> f, 
        double a,               double b, 
        double delta= 0.001,    double eps=0.0001, //0.0073751 is the limit for 1/sqrt(x) 0 to 1
        double f2=double.NaN,   double f3=double.NaN){
        double h = b-a;
        if(double.IsNaN(f2)){
            f2 = f(a + 2.0/6.0*h);
            f3 = f(a + 4.0/6.0*h);
        }
        double f1 = f(a + h/6.0);
        double f4 = f(a + 5*h/6.0);
        double Q = (2*f1 + f2 + f3 + 2*f4)/6.0 * h;
        double q = (f1 + f2 + f3 + f4)/4.0 * h;
        if( Abs(Q-q) <= (delta + eps*Abs(Q))){
            return Q;
        }
        else {
            return integrate(f,a,(a+b)/2.0, delta/Sqrt(2.0), eps, f1, f2) + integrate(f,(a+b)/2.0, b, delta/Sqrt(2.0), eps, f3,f4);
        }
    }
    public static double ccquad(
        Func<double,double> f, 
        double a,               double b, 
        double delta= 0.0001,   double eps=0.001) //0.0073751 is the limit for 1/sqrt(x) 0 to 1
    {
        Func<double,double> F = delegate(double x){return f((a+b)/2.0 + (b-a)/2.0 * Cos(x))*Sin(x)*(b-a)/2.0; };
        return integrate(F,0, PI);
    }
}