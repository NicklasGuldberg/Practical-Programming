using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public class cspline{
    public double[] x,y,b,c,d,dx,p;
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
	public cspline(double[] xs,double[] ys){
        //This calculates the coefficients starting with c[0] and then recursion
		if(!(xs.Length == ys.Length)) throw new Exception("xs and ys must have the same size.");
        n = xs.Length;
        x = xs;
        y = ys;
        b = new double[n];
        c = new double[n-1];
        d = new double[n-1];
        dx = new double[n-1]; //This line is suspected
        p = new double[n-1];
        double[] B = new double[n];
        double[] D = new double[n];
        double[] Q = new double[n-1];
        for(int i = 0; i<n-1; i++){
            dx[i] = x[i+1] - x[i];
            p[i] = (y[i+1] - y[i]) / dx[i];
        }
        // Elements in the main diagonal
        D[0] = 2;D[n-1] = 2; 
        for(int i = 0; i<n-2; i++) D[i+1] = 2 * dx[i] / dx[i+1] + 2 ;
        // Off diagonal elements
        Q[0] = 1; 
        for(int i = 0; i<n-2; i++) Q[i+1] = dx[i] / dx[i+1];
        //Right hand side
        B[0] = 3 * p[0]; B[n-1] = 3 * p[n-2];
        for(int i = 0; i<n-2; i++) B[i+1] = 3 * (p[i] + p[i+1]* dx[i]/dx[i+1]);
        //Gauss elimination 
        for(int i = 1; i<n-1; i++){
            D[i] = D[i] - Q[i-1] / D[i-1];
            B[i] = B[i] - B[i-1] / D[i-1];
        }
        //Backsubstitution
        b[n-1] = B[n-1] / D[n-1];
        for(int i = n-2; i>= 0; i--) b[i] = (B[i] - Q[i] * b[i+1]) / D[i];
        //This should be checked if different with c[0] = 0
        for(int i = 0; i<n-1; ++i){
            c[i] = (- 2 * b[i] - b[i+1] + 3 * p[i]  )/dx[i]; //This seems to produce c[0] = 0.
            d[i] = (b[i] + b[i+1] - 2 * p[i]) /(dx[i]*dx[i]);
        }
	}
    
	public double spline(double z){
        //This is just the spline function. It is important that z is restricted to x[0] < z < x[n]
        int i = binsearch(x,z);
        double s_i = y[i] + b[i] * (z - x[i]) + c[i] * (z-x[i])*(z-x[i]) + d[i] * Pow((z-x[i]), 3); 
        return s_i;
    }
    
	public double derivative(double z){
        int i = binsearch(x,z);
        double sdot_i = b[i] + 2 * c[i] * (z - x[i]) + 3 * d[i] * (z - x[i])*(z - x[i]);
        return sdot_i;
    }
    
	public double integral(double z){
        int i = binsearch(x,z);
        double sint = 0;
        for(int j = 0; j<i; ++j){
            sint += y[j] * dx[j] + 1.0/2 * b[j] * dx[j] * dx[j] + 1.0/3 * c[j] * Pow(dx[j],3) +  1.0/4 * d[j] * Pow(dx[j],4);
        }
        sint += y[i] * (z - x[i]) + 1.0/2 * b[i] * (z - x[i]) * (z - x[i]) + 1.0/3 * c[i] * Pow((z - x[i]),3) +  1.0/4 * d[i] * Pow((z - x[i]),4);
        return sint;
    }
}