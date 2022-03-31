using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public class qspline{
    public double[] x,y,b,c,dx,p;
    public int n;
    //Binsearch is taken from the part A.
    public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2; //Division of integers throws away residue and output is always an integer e.g. 3/2 = 1
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
	}
	public qspline(double[] xs,double[] ys){
        //This calculates the coefficients starting with c[0] and then recursion
		if(!(xs.Length == ys.Length)) throw new Exception("xs and ys must have the same size.");
        n = xs.Length;
        dx = new double[n-1];
        p = new double[n-1];
        c = new double[n-1];
        b = new double[n-1];
        x = xs;
        y = ys;
        for(int i = 0; i<n-1; i++){
            dx[i] = x[i+1] - x[i];
            p[i] = (y[i+1] - y[i]) / dx[i];
        }
        // First the forwards recursion
        c[0] = 0;
        for(int i = 0; i<n-2; i++){
            c[i+1] = 1.0/dx[i+1] * ( p[i+1] - p[i] - c[i] * dx[i]);
            // WriteLine($"{i+1}");
        }   
        // Now the backwards recursion
        c[n-2] =  0.5 * c[n-2];
        for(int i = n-3; i>= 0; --i){   
            c[i] = 1.0/dx[i] * (p[i+1] - p[i] - c[i+1] * dx[i+1]);
            // WriteLine($"{c[i]}");
        }
        // And finally assigning the b[i]'s
        for(int i = 0; i<n-1; ++i)      b[i] = p[i] - c[i] * dx[i];
	}

	public double spline(double z){
        //This is just the spline function. It is important that z is restricted to x[0] < z < x[n]
        int i = binsearch(x,z);
        double s_i = y[i] + b[i] * (z - x[i]) + c[i] * (z - x[i])*(z - x[i]);
        return s_i;
    }
	public double derivative(double z){
        int i = binsearch(x,z);
        double sdot_i = b[i] + 2*c[i] * (z - x[i]);
        return sdot_i;
    }
	public double integral(double z){
        int i = binsearch(x,z);
        double sint = 0;
        for(int j = 0; j<i; ++j){
            sint += y[j] * dx[j] + 0.5 * b[j] * dx[j] * dx[j] + 1.0/3.0 * c[j] * Pow(dx[j],3);
        }
        sint += y[i] * (z- x[i]) + 0.5 * b[i] * (z - x[i]) * (z - x[i])  + 1.0/3.0 * c[i] * (z - x[i])*(z - x[i])*(z - x[i]);
        return sint;
    }
}