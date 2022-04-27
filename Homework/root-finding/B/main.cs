using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static NM;
class main{
    static double F(double r, double eps){
        Func<double,vector,vector> f = delegate(double t, vector y){
            vector dydr = new vector(y.size);
            dydr[0] = y[1];
            dydr[1] = - 2 * (eps + 1.0/t) * y[0]; 
            return dydr;
        };
        double rmin = 0.0001;
        if(r<rmin){
            return r - r*r;
        }
        else{
            vector y0 = new vector(rmin - rmin*rmin, 1 - 2*rmin); //initial values 
            vector y = ODE.driver(f,rmin,y0,r);
            return y[0];
        }
    }
    // static double M(double eps, double rmax = 10){
    //     return F(rmax, eps);
    // }
    static void Main(){
        var data = new System.IO.StreamWriter("data.txt");

        double rmax = 8; 
        Func<vector,vector> M = delegate(vector eps){
            return new vector(F(rmax, eps[0]));
        };
        vector epsguess =  new vector(-0.99);
        var eps0 = newton(M, epsguess); 
        eps0.print();
        WriteLine();
        WriteLine($"With rmax = {rmax},  epsguess = {epsguess[0]}");
        Func<double,double> f0 = delegate(double r){return r * Exp(-r);};

        for(double x = 0; x<rmax; x+= 0.01){
            data.WriteLine($"{x}, {F(x, eps0[0])}, {f0(x)}");
        }
        data.Close();

    }    
}