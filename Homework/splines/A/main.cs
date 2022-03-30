using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static Linterp;
class main{
    static void Main(){
        int N = 10;
        double xmin = 0;
        double xmax = 6;
        double[] x = new double[N];
        double[] y = new double[N];
        var PointsOut = new System.IO.StreamWriter("Points.txt");
        for(int j = 0; j< N; j+=1){
            x[j] = xmin + (xmax - xmin)/N*j;
            y[j] = Sin(x[j]);
            PointsOut.WriteLine($"{x[j]} {y[j]}");
        };
        PointsOut.Close();

        // This should plot the sin function. 
        var OrgFuncOut = new System.IO.StreamWriter("orgfunc.txt");
        int Ns = N*100;
        double[] xs = new double[Ns];
        double[] ys = new double[Ns];
        for(int k = 0; k<Ns; ++k){
            xs[k] = xmin + (xmax - xmin)/Ns*k;
            ys[k] = Sin(xs[k]);
            OrgFuncOut.WriteLine($"{xs[k]} {ys[k]}");
        }
        OrgFuncOut.Close();
        // This plots the interpolated function
        for(double j=x[0]; j<x[x.Length-1]; j+=0.05){  //It is very important we stay between x[0] and x[end]
            WriteLine($"{j} {linterp(x,y,j)} {linterpInteg(x,y,j)}");
        };
        
    }
}