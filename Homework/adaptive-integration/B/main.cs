using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static quad;
using static vector;
class main{
    static void Main(){
        //We test our integrator with four different functions and compare with the analytical result
        int i = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        Func<double,double> fi = delegate(double x){++i; return 1.0/Sqrt(x);};
        Func<double,double> fj = delegate(double x){++j; return 1.0/Sqrt(x);};
        Func<double,double> gk = delegate(double x){++k;return Log(x)/Sqrt(x);};
        Func<double,double> gl = delegate(double x){++l;return Log(x)/Sqrt(x);};
        WriteLine($"ccquad(1/Sqrt(x),0,1) = 2: {approx(ccquad(fi, 0.0,1.0),2.0, 1e-4)} to 4 decimal places");
        WriteLine($"ccquad(Log(x)/Sqrt(x)) = -4: {approx(ccquad(gk, 0.0,1.0),-4.0, 1e-4)} to 4 decimal places");
        WriteLine($"integrate(1/Sqrt(x),0,1) = 2: {approx(integrate(fj, 0.0,1.0),2.0, 1e-4)} to 4 decimal places");
        WriteLine($"integrate(Log(x)/Sqrt(x)) = -4: {approx(integrate(gl, 0.0,1.0),-4.0, 1e-4)} to 4 decimal places");
        WriteLine();
        WriteLine($"To integrate 1/Sqrt(x), the Clenshaw-Curtis routine called the function {i} times");
        WriteLine($"To integrate 1/Sqrt(x), the normal routine called the function {j} times");
        WriteLine($"To integrate Log(x)/Sqrt(x), the Clenshaw-Curtis routine called the function {k} times");
        WriteLine($"To integrate Log(x)/Sqrt(x), the normal routine called the function {l} times");

   }    
}