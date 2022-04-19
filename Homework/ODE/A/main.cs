using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static Func<double,vector,vector> f = delegate(double x, vector y){
            return new vector(y[1], -y[0]);
        };
    
    static Func<double,vector,vector> pend = delegate(double x, vector y){
        //We're looking at the second order DE, theta''(t) + b*theta'(t) + c*sin(theta(t)) = 0 
        double theta = y[0];
        double omega = y[1];
        double b = 0.25;
        double c = 5.0; 
        return new vector(omega, -b*omega - c * Sin(theta));
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
        WriteLine();
        WriteLine();

        //Example from scipy.integrate.odeint manual
        vector y0 = new vector(PI - 0.1, 0.0);
        for(int i = 0; i<101; ++i){
            double t = i/101.0*10;
            vector y = ODE.driver(pend,0,y0,t);
            WriteLine($"{t}, {y[0]}, {y[1]}");
        } 
        
   }    
}