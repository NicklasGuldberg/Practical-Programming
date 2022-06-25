using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
using static GlobalMinimizer;
using static minimizer;
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
    Func<vector, double> g = delegate(vector v){
        double x = v[0];
        double y = v[1];
        return x + y;
    };

        vector v0 = new vector("-2, 2, -2, 2");
        vector start = new vector(0.0,0.0);
        (vector xmin, vector optstart, int steps) = hmin(f, v0,10000, 0.0001);
        (vector xmin1, int steps1) = qnewton(f, start, 0.0001);
        optstart.print("optstart =");
        xmin.print("xmin =");
        WriteLine($"steps = {steps}");
        xmin1.print("xmin =");
        WriteLine($"steps = {steps1}");
   }    
}