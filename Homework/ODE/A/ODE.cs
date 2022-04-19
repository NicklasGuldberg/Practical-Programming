using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 
using static vector;
public static class ODE{
    public static (vector,vector) rkstep23(Func<double,vector,vector> f, double x, vector y, double h){
        //Bogacki-Shampine method   (does not utilize FSAL (First Same As Last))
        vector k0 = f(x,y);
        vector k1 = f(x + 0.5 * h, y + 0.5*h*k0);
        vector k2 = f(x + 0.75 * h, y + + 0.75*h*k1);
        vector k3 = f(x + h, y + 2.0/9*h*k0 + 1.0/3*h*k1 + 4.0/9*h*k2); 
        vector k = 2.0/9 * k0 + 1.0/3 * k1 + 4.0/9 * k2;
        vector kstar = 7.0/24 * k0 + 0.25 * k1 + 1.0/3 * k2 + 1.0/8 * k3;
        vector yh = y + h * k;
        vector err = h*(k - kstar);
        return (yh,err);
    }
    public static vector driver(
        Func<double,vector,vector> f, 
        double a, 
        vector ya, 
        double b, 
        double h=0.01, 
        double acc=0.01, 
        double eps = 0.01){
        //this driver compares all vectors elements and not just the norm.
        if(a>b) throw new Exception("Driver: a>b");
        double x = a;
        vector y = ya;
        double frac;
        do {
            if(x>=b) return y;
            if(x + h > b) h = b-x; 
            var (yh, err) = rkstep23(f, x, y, h);
            double Tol = Min(acc, yh.norm()*eps) * Sqrt(h/(b-a)) ;
            double Err = err.norm();
            if(Err <= Tol){
                x += h;
                y = yh;
                // WriteLine($"{x}, {y[0]}");
            }
            if(Err > 0) h *= Pow(Tol/Err, 0.25) * 0.95; 
        }while(true);
    }
}