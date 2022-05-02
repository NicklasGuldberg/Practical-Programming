using System;
using static System.Math;
using static System.Console;
using static integrate;

class main{
    static double erf(double z){
        if(z<0)
            return - erf(-z);
        else{
            Func<double,double> f = delegate(double t){return Exp(-t*t);};
            double result = 2/Sqrt(PI)*quad(f,a:0,b:z, acc:1e-6, eps:0);
            return result;
        }
    }

    static void Main(){
        Func<double,double> f = delegate(double x){return Log(x)/Sqrt(x);};
        double result = quad(f,a:0,b:1, acc:1e-6, eps:0);
        //WriteLine($"result = {result}"); //test
        //WriteLine($"{erf(1)}");
        for (double x=-3; x<= 3; x+=1.0/8)
            WriteLine($"{x}, {erf(x)}");
    }
}