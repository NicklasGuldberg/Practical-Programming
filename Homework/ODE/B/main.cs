using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static Func<double,vector,vector> f = delegate(double x, vector y){
            return new vector(y[1], -y[0]);
        };
    
    static void Main(){

        //Example with u'' = -u
        vector ya = new vector(0.0, 1.0);
        double N = 50;
        for(int i = 0; i<N; ++i){
            double x = 2*PI * i/N;
            vector y = ODE.driver(f,0,ya,x);
            WriteLine($"{x}, {y[0]}, {0}");
        }
   }    
}