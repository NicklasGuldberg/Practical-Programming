using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
class main{
    static void Main(){
        // WriteLine($"corput number of 1234 is {corput(1235,3)}");

        Func<vector,double> f = delegate(vector v){return v[0] + v[1] + v[2]; };
        vector a = new vector("0, 0, 0");
        vector b = new vector("1, 1, 1");
        int N = 1000;
        var (result1, err1) = haltonmc(f,a,b,N);
        var (result2, err2) = plainmc(f,a,b,N);
        WriteLine("\n");
        WriteLine($"Halton quasi-random sequence Monte Carlo integration with N={N} of f(x,y,z) = x + y + z from [0,0,0] to [1,1,1]");
        WriteLine($"= {result1}, with error approximately {err1}");
        WriteLine($"Analytical result should be 3/2");

        WriteLine();
        WriteLine($"Plain Monte Carlo integration with N={N} of f(x,y,z) = x + y + z from [0,0,0] to [1,1,1]");
        WriteLine($"= {result2}, with error approximately {err2}");
        WriteLine($"Analytical result should be 3/2");
        WriteLine();

        WriteLine("We note that the error of the quasi-random is significantly less than the plain integrator");
   }    
}