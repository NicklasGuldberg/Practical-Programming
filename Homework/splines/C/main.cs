using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static cspline;
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
            y[i] = rnd.Next(-1,2);
            WriteLine($"{x[i]} {y[i]}");
        }
        WriteLine();
        WriteLine();
        // Two empty lines for another plot
        cspline cs = new cspline(x,y);
        // WriteLine($"{cs.c[2]}");
        for(double i = cs.x[0]; i<cs.x[cs.n-1]; i += 0.01){
            WriteLine($"{i} {cs.spline(i)}");
        }
        
        WriteLine();
        WriteLine();

        for(double i = cs.x[0]; i<cs.x[cs.n-1]; i += 0.01){
            WriteLine($"{i} {cs.derivative(i)}");
        }
        WriteLine();
        WriteLine();

        for(double i = cs.x[0]; i<cs.x[cs.n-1]; i += 0.01){
            WriteLine($"{i} {cs.integral(i)}");
        }
    }
}