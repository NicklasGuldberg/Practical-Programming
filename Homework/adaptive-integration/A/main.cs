using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static quad;
using static vector;
class main{
    static void Main(){
        //We test our integrator with four different functions and compare with the analytical result
        Func<double,double> f = delegate(double x){return 1/Sqrt(x);};
        Func<double,double> g = delegate(double x){return 4.0*Sqrt(1 - x*x);};
        Func<double,double> h = delegate(double x){return Log(x)/Sqrt(x);};
        WriteLine($"integrate(Sqrt(x),0,1) = 2/3: {approx(integrate(Sqrt, 0.0,1.0),2.0/3, 1e-4)} to 4 decimal places");
        WriteLine($"integrate(1/Sqrt(x),0,1) = 2: {approx(integrate(f, 0,1),2, 1e-4)} to 4 decimal places");
        WriteLine($"integrate(4.0*Sqrt(1 - x*x),0,1) = PI: {approx(integrate(g, 0.0,1.0),PI, 1e-4)} to 4 decimal places");
        WriteLine($"integrate(Log(x)/Sqrt(x),0,1) = -4: {approx(integrate(h, 0,1),-4, 1e-4)} to 4 decimal places");
   }    
}