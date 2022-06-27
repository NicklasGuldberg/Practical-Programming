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
    double a = 1;
    double b = 100;
	Func<vector, double> f = delegate(vector v){
        //this is the Rosenbrock's valley function for a=1 b=100
		double x = v[0];
		double y = v[1];
		return Pow((a-x),2) + b*Pow(y-x*x,2);
	};
    
        // vector v0 = new vector("-2, 2, -2, 2");
        // vector start = new vector(0.0,0.0);
        // (vector xmin, vector optstart, int steps) = thmin(f, v0,2, 0.0001);
        // (vector xmin1, int steps1) = qnewton(f, start, 0.0001);
        // optstart.print("optstart =");
        // xmin.print("xmin =");
        // WriteLine($"steps = {steps}");
        // start.print("start =");
        // xmin1.print("xmin =");
        // WriteLine($"steps = {steps1}");
    double time = 1.0;
    WriteLine();
    WriteLine("Rosenbrock's valley function");
    WriteLine("---------------------------------------------------------------");
    vector v0 = new vector(0.0, 0.0); 
    vector range = new vector("-2, 2, -1, 3");
    var (xmin,optstart,steps,points) = thmin(f, range,time, 0.0001);
    var (xmin2,steps2) = qnewton(f, v0, 0.0001);
    WriteLine("\t f(x,y) = (1-x)^2 + 100(y-x^2)^2");
    WriteLine($"The function is sampled for {time} second(s) in the range:");
    WriteLine($"{range[0]} < x < {range[1]}");
    WriteLine($"{range[2]} < y < {range[3]}");
    WriteLine($"In total {points} points were sampled");
    optstart.print($"The best point found was at ");//({optstart[0]}, {optstart[1]})");
    xmin.print($"Quasi-newton minimizer determined minimum at ");//({xmin[0]},{xmin[1]})");
    WriteLine($"Number of steps taken is {steps}");
    WriteLine($"");
    v0.print("For comparison a start guess at");
    xmin2.print("produces a minimum found at ");
    WriteLine($"after {steps2} steps.");
    //var test = gradient(f,vopt);
    //test.print("grad(vopt) =");
    WriteLine("According to wikipedia the minimum should be at f(1,1) = 0");
    WriteLine("---------------------------------------------------------------");

    f = delegate(vector v){
        double x = v[0];
        double y = v[1];
        return  - 20 * Exp(- 0.2*Sqrt(0.5 * (x*x + y*y))) - Exp(0.5 * (Cos(2*PI*x) + Cos(2*PI*y))) + Exp(1) + 20; 
    }; 
    
    WriteLine();
    WriteLine("Ackley function");
    WriteLine("---------------------------------------------------------------");
    v0 = new vector(1, 1); 
    range = new vector("-5, 5, -5, 5");
    (xmin,optstart,steps,points) = thmin(f, range,time, 0.0001);
    (xmin2,steps2) = qnewton(f, v0, 0.0001);
    WriteLine("\t f(x,y) = - 20 * Exp(- 0.2*Sqrt(0.5 * (x^2+ y^2))) - Exp(0.5 * (Cos(2*PI*x) + Cos(2*PI*y))) + e + 20");
    WriteLine($"The function is sampled for {time} second(s) in the range:");
    WriteLine($"{range[0]} < x < {range[1]}");
    WriteLine($"{range[2]} < y < {range[3]}");
    WriteLine($"In total {points} points were sampled");
    optstart.print($"The best point found was at ");//({optstart[0]}, {optstart[1]})");
    xmin.print($"Quasi-newton minimizer determined minimum at ");//({xmin[0]},{xmin[1]})");
    WriteLine($"Number of steps taken is {steps}");
    WriteLine($"");
    v0.print("For comparison a start guess at");
    xmin2.print("produces a minimum found at ");
    WriteLine($"after {steps2} steps.");
    WriteLine("According to wikipedia the minimum should be at f(0, 0) = 0");
    WriteLine("---------------------------------------------------------------");
    
    f = delegate(vector v){
        double x = v[0];
        double y = v[1];
        return 2 * x*x - 1.05*x*x*x*x + x*x*x*x*x*x/6.0 + x*y + y*y; 
    }; 
    
    WriteLine();
    WriteLine("Three-hump camel function");
    WriteLine("---------------------------------------------------------------");
    v0 = new vector(1,1); 
    range = new vector("-5, 5, -5, 5");
    (xmin,optstart,steps,points) = thmin(f, range,time, 0.0001);
    (xmin2,steps2) = qnewton(f, v0, 0.0001);
    WriteLine("\t f(x,y) = 2*x^2 - 1.05*x^4 + x^6/6 + x*y y^2");
    WriteLine($"The function is sampled for {time} second(s) in the range:");
    WriteLine($"{range[0]} < x < {range[1]}");
    WriteLine($"{range[2]} < y < {range[3]}");
    WriteLine($"In total {points} points were sampled");
    optstart.print($"The best point found was at ");//({optstart[0]}, {optstart[1]})");
    xmin.print($"Quasi-newton minimizer determined minimum at ");//({xmin[0]},{xmin[1]})");
    WriteLine($"Number of steps taken is {steps}");
    WriteLine($"");
    v0.print("For comparison a start guess at");
    xmin2.print("produces a minimum found at ");
    WriteLine($"after {steps2} steps.");
    WriteLine("According to wikipedia the minimum should be at f(0, 0) = 0");
    WriteLine("---------------------------------------------------------------");

    f = delegate(vector v){
        double x = v[0];
        double y = v[1];
        return  -Cos(x) * Cos(y) * Exp(- ((x-PI)*(x-PI) + (y-PI)*(y-PI))); 
    }; 

    WriteLine();
    WriteLine("Easom function");
    WriteLine("---------------------------------------------------------------");
    v0 = new vector(1, 1); 
    range = new vector("0, 6, 0, 6");
    (xmin,optstart,steps,points) = thmin(f, range,time, 0.0001);
    (xmin2,steps2) = qnewton(f, v0, 0.0001);
    WriteLine("\t f(x,y) = - Cos(x) * Cos(y) * Exp(- ((x-PI)^2 + (y-PI)^2))");
    WriteLine($"The function is sampled for {time} second(s) in the range:");
    WriteLine($"{range[0]} < x < {range[1]}");
    WriteLine($"{range[2]} < y < {range[3]}");
    WriteLine($"In total {points} points were sampled");
    optstart.print($"The best point found was at ");//({optstart[0]}, {optstart[1]})");
    xmin.print($"Quasi-newton minimizer determined minimum at ");//({xmin[0]},{xmin[1]})");
    WriteLine($"Number of steps taken is {steps}");
    WriteLine($"");
    v0.print("For comparison a start guess at");
    xmin2.print("produces a minimum found at ");
    WriteLine($"after {steps2} steps.");
    WriteLine("According to wikipedia the minimum should be at f(pi,pi) = - 1");
    WriteLine("---------------------------------------------------------------");
 
   }    
}