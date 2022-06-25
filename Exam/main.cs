using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
using static GlobalMinimizer;
class main{
    static void Main(){
    // int N = 1000;
    // vector x = new vector(2);
    // for(int i = 0; i<N; ++i){
    //     halton(i,x);
    //     WriteLine($"{x[0]}, {x[1]}");
    // }
	Func<vector, double> f = delegate(vector v){
        //this is the Rosenbrock's valley function for a=1 b=100
		double x = v[0];
		double y = v[1];
		return Pow((1-x),2) + 100*Pow(y-x*x,2);
	};

        vector v0 = new vector("0.75, 1.25, 0.75, 1.25");
        (vector xmin, vector optstart, int steps) = hmin(f, v0,1000);
        optstart.print("optstart =");
        xmin.print("xmin =");
        WriteLine($"steps = {steps}");
   }    
}