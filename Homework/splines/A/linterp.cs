using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class Linterp{
    public static double linterp(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx = x[i+1] - x[i];
        double dy = y[i+1] - y[i];
        return dy/dx*(z-x[i]) + y[i];
        }

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

    public static double linterpInteg(double[] x, double[] y, double z){
        // This function does the intergral of the between all the points up to i'th bin where it integrates from x[i] to z.
        int i = binsearch(x,z);
        double Int = 0;
        for(int j = 0; j<i; ++j){
            Int += 0.5 * (x[j+1] - x[j]) * (y[j] + y[j+1]);
        }
        Int += (z - x[i]) * (y[i] + 0.5 * (y[i+1]-y[i])/(x[i+1]-x[i])*(z-x[i]) );
        return Int;
    }
}