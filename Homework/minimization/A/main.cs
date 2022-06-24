using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static minimizer;
class main{
    static void Main(){
	Func<vector, double> f = delegate(vector v){
		double x = v[0];
		double y = v[1];
		return Pow((1-x),2) + 100*Pow(y-x*x,2);
	};
	Func<vector,double> g = delegate(vector v){
		double x = v[0];
		double y = v[1];
		return Pow(x*x + y -11, 2) + Pow(x+y*y -7,2);
	};
	Func<vector,double> h = delegate(vector v){
		return (v[0]-2)*(v[0]-2) + (v[1] - 3)*(v[1] - 3);
	};

	WriteLine();
	WriteLine("Rosenbrock's valley function");
	WriteLine("-------------------------");
	vector v0 = new vector(0.0, 0.0); //Now works for 0,0 guess too !! !
	var (vopt,steps) = qnewton(f, v0, 0.0001);
	WriteLine("f(x,y) = (1-x)^2 + 100(y-x^2)^2");
	v0.print("Start guess: (x0,y0)	= ");
	vopt.print("Minimum found at (x,y)	= ");
	WriteLine($"Steps taken: {steps}");
	//var test = gradient(f,vopt);
	//test.print("grad(vopt) =");
	WriteLine("According to wikipedia minimum should be at (x,y) = (1,1)");
	WriteLine("------------------------");


	WriteLine();
	WriteLine("Himmelblau's function");
	WriteLine("-------------------------");
	var (vopt2,steps2) = qnewton(g, v0, 0.0001);
	WriteLine("g(x,y) = (x^2 + y - 11)^2 + (x + y^2 - 7)^2");
	v0.print("Start guess: (x0,y0)	= ");
	vopt2.print("Minimum found at (x,y)	= ");
	WriteLine($"Steps taken: {steps2}");
	//var test = gradient(f,vopt);
	//test.print("grad(vopt) =");
	WriteLine("According to wikipedia minimum exist at (x,y) = (3,2), (-2.805, 3.131), (-3.779,-3.283) and (3.584,-1.848)");
	WriteLine("------------------------");



   }    
}
