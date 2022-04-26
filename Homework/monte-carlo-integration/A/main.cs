using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
class main{
    static void Main(){
        Func<vector,double> f = delegate(vector v){return v[0] + v[1] + v[2]; };
        vector a1 = new vector("0, 0, 0");
        vector b1 = new vector("1, 1, 1");
        int N1 = 1000;
        var (result1, err1) = plainmc(f,a1,b1,N1);
        WriteLine("\n");
        WriteLine($"Plain Monte Carlo integration with N={N1} of f(x,y,z) = x + y + z from [0,0,0] to [1,1,1]");
        WriteLine($"= {result1}, with error approximately {err1}");
        WriteLine($"Analytical result should be 3/2");
        WriteLine();

        vector a2 = new vector("0, 0, 0");
        vector b2 = new vector($"{PI}, {PI}, {PI}");
        int N2 = 100000;
        Func<vector,double> gamma = delegate(vector v){return 1.0/(PI*PI*PI) * 1.0/(1 - Cos(v[0]) * Cos(v[1]) * Cos(v[2])) ;};
        var (result2, err2) = plainmc(gamma,a2,b2,N2);
        WriteLine($"Plain Monte Carlo integration with N={N2} of f(x,y,z) = 1/pi^2 * (1 - cos(x)*cos(y)*cos(z))^-1 from [0,0,0] to [pi,pi,pi]");
        WriteLine($"= {result2} with error approximately {err2}");
        WriteLine("Precise result should be 1.3932039296856768591842462603255");
        WriteLine();
   }    
}