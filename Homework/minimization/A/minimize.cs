using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static vector;
using static matrix;
public static class minimizer{

	static matrix SR1(Func<vector,double> f, vector x, vector s, matrix B, vector df){
		//Symmetric-rank-1 update
		//if(df == new vector("0, 0")) df = gradient(f,x);
		vector y = gradient(f,x+s) - df;
		vector u = s - B*y;
		double denom = u%y;
		if(denom < 1e-6) return B;
		matrix num = outer(u, u);
		return num/denom;
	}

	static vector gradient(Func<vector,double> f, vector x){  	
		//Computes a numerical gradient
		int n = x.size;
		vector df = new vector(n);
		vector dx = new vector(n);
		dx.set_zero();
		for(int i = 0; i<n; ++i){
			dx[i] = x[i]*Pow(2,-26); 
			df[i] = (f(x + dx) - f(x))/ dx[i];
			dx[i] = 0;
		}
		return df;
	}

	public static vector qnewton(Func<vector,double> f, vector start, double acc=0.001){
		int n = start.size;
		matrix B = new matrix(n,n);
		B.set_unity();
		vector x = start;
		vector df = gradient(f,x); 
		vector deltax = new vector(n);

		do{
			deltax = -B * df;
			double lambda = 1;
			while( !(f(x + lambda* deltax) < f(x)) & lambda > 1.0/32){
				lambda *= 0.5;
			};
			vector s = lambda*deltax; //This is the step
			if (lambda > 1.0/32) {
				//if lambda is not too small and f(x + lambda*deltax) < f(x) we get to here
				//now for the update
				B += SR1(f,x,s,B,df); 
				x += s; //This step needs to be done last so not to interfere with the update of B
			} else {
				x += s;
				B.set_unity();
				df = gradient(f,x); //This is done last df is not updated at the start of the while loop.
			}
		} while(df.norm()<acc);

    	    vector a = new vector(0,0);
    	    return a;
    	}





}
