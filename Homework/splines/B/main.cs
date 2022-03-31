using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static qspline;
class main{
    static void Main(){
        Random rnd = new Random();
        int n = 10;
        double xmin = 0;
        double xmax = 5;
        var x = new double[n];
        var y = new double[n];
        for(int i=0; i<n; i++){
            x[i] = xmin + i/Convert.ToDouble(n) * (xmax - xmin);
            y[i] = rnd.Next(0,5);
            WriteLine($"{x[i]} {y[i]}");
        }
        WriteLine();
        WriteLine();
        // Two empty lines for another plot.
        qspline qs = new qspline(x,y);
        for(double i = qs.x[0]; i<qs.x[qs.n-1]; i += 0.01){
            WriteLine($"{i} {qs.spline(i)}");
        }

        WriteLine();
        WriteLine();

        for(double i = qs.x[0]; i<qs.x[qs.n-1]; i += 0.01){
            WriteLine($"{i} {qs.derivative(i)}");
        }
    }
}