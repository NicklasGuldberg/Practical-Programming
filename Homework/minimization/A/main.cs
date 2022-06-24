using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static minimizer;
class main{
    static void Main(){
        WriteLine("Hello World");        
	Func<vector, double> f = delegate(vector v){
		double x = v[0];
		double y = v[1];
		return Pow((1-x),2) + 100*Pow(y-x*x,2);
	};
	Func<vector,double> h = delegate(vector v){
		return (v[0]-2)*(v[0]-2) + (v[1] - 3)*(v[1] - 3);
	};

	vector v0 = new vector(0.1, 0.1); //Everything breaks when the start guess is 0. Not sure why??
	vector vopt = qnewton(f, v0, 0.00001);
	vopt.print("vopt =");
	var test = gradient(f,vopt);
	test.print("grad(vopt) =");


	Func<vector,double> g = delegate(vector v){
		double x = v[0];
		double y = v[1];
		return Pow(x*x + y -11, 2) + Pow(x+y*y -7,2);
	};



   }    
}
