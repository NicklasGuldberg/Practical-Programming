using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public class qspline{
    public double[] x,y,b,c;
	public qspline(double[] xs,double[] ys){
        //This calculates the coefficients starting with c[0] and then recursion
		if(!(xs.Length == ys.Length)) throw new Exception("xs and ys must have the same size.");
        int n = xs.Length;
        double[] dx = new double[n-1];
        double[] p = new double[n-1];
        double[] c = new double[n-1];
        double[] b = new double[n-1];
        x = xs;
        y = ys;
        b[0] = (ys[1] - ys[0])/(xs[1]-xs[0]);
        for(int i = 0; i<n-1; i++){
            dx[i] = x[i+1] - x[i];
            p[i] = (y[i+1] - y[i]) / dx[i];
        }
        // First the forwards recursion
        c[0] = 0;
        for(int i = 0; i<n-2; i++)      c[i+1] = 1.0/dx[i+1] * ( p[i+1] - p[i] - c[i] * dx[i]);

        // Now the backwards recursion
        c[n-2] =  0.5 * c[n-2];
        for(int i = n-3; i>= 0; --i)    c[i] = 1/dx[i] * (p[i+1] - p[i] - c[i+1] * dx[i+1]);
        // And finally assigning the b[i]'s
        for(int i = 0; i<n-1; ++i)      b[i] = p[i] - c[i] * dx[i];
	}
	// public double spline(double z){/* evaluate the spline */}
	// public double derivative(double z){/* evaluate the derivative */}
	// public double integral(double z){/* evaluate the integral */}
}