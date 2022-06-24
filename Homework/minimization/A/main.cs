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
		
	Func<vector,double> g = delegate(vector v){
		double x = v[0];
		double y = v[1];
		return Pow(x*x + y -11, 2) + Pow(x+y*y -7,2);
	};


   }    
}
