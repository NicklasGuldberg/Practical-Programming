using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public static class quad{
    public static double integrate2(
        Func<double,double> f, 
        double a,               double b, 
        double delta= 0.1,      double eps=0.03, //0.0073751 is the limit for 1/sqrt(x) 0 to 1
        double f2=double.NaN,   double f3=double.NaN,
        double f6=double.NaN,   double f7=double.NaN, int i = 0){
        // try{
        double h = b-a;
        if(double.IsNaN(f3)){
            f2 = f(a + 2.0/12.0*h);
            f3 = f(a + 4.0/12.0*h);
            f6 = f(a + 8.0/12.0*h);
            f7 = f(a + 10.0/12.0*h);
        }
        double f1 = f(a + 1.0/12.0*h);
        double f4 = f(a + 5.0/12.0*h);
        double f5 = f(a + 7.0/12.0*h);
        double f8 = f(a + 11.0/12.0*h);
        double Q = (4738.0/19845.0*f1 - 59.0/567.0*f2 + 5869.0/13230.0*f3 - 74.0/945.0*f4 + 4738.0/19845.0*f8 - 59.0/567.0*f7 + 5869.0/13230.0*f6 - 74.0/945.0*f5)*h;
        double q = (208.0/945.0*f1 - 7.0/135.0*f2 + 209.0/630.0*f3 + 208.0/945.0*f6 - 7.0/135.0*f7 + 209.0/630.0*f8)*h;
        ++i;
        if( Abs(Q-q) <= Min(delta, eps*Abs(Q))){
            // WriteLine(q);
            // WriteLine(Q);
            // WriteLine($"xf1 = {a + 2.0/12.0*h}");
            return Q;
        }
        else {
            // WriteLine($"i = {i}");
            return integrate2(f,a,(a+b)/2.0, delta/Sqrt(2.0), eps, f1, f2, f3, f4,i) + integrate2(f,(a+b)/2.0, b, delta/Sqrt(2.0), eps, f5, f6, f7, f8,i);
        }
        // } catch (Exception ex){
        //     WriteLine(ex.Message);
        //     return 0;
        // }
    }
    public static double integrate(
        Func<double,double> f, 
        double a,               double b, 
        double delta= 0.0001,      double eps=0.001, //0.0073751 is the limit for 1/sqrt(x) 0 to 1
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
        if( Abs(Q-q) <= Min(delta, eps*Abs(Q))){
            return Q;
        }
        else {
            return integrate(f,a,(a+b)/2.0, delta/Sqrt(2.0), eps, f1, f2) + integrate(f,(a+b)/2.0, b, delta/Sqrt(2.0), eps, f3,f4);
        }
    }
    
}