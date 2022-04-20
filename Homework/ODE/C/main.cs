using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static Func<double,vector,vector> f = delegate(double x, vector y){
            return new vector(y[1], -y[0]);
        };
    static Func<double,vector,vector> threebody = delegate(double t, vector y){
        vector r1 = new vector(y[0], y[1]);
        vector v1 = new vector(y[2], y[3]);
        vector r2 = new vector(y[4], y[5]);
        vector v2 = new vector(y[6], y[7]);
        vector r3 = new vector(y[8], y[9]);
        vector v3 = new vector(y[10],y[11]);
        vector r1r2 = r2 - r1;
        vector r1r3 = r3 - r1;
        vector r2r3 = r3 - r2;
        vector F1 = r1r2 / (r1r2.norm()*r1r2.norm()*r1r2.norm()) + r1r3 / (r1r3.norm()*r1r3.norm()*r1r3.norm());
        vector F2 = - r1r2 / (r1r2.norm()*r1r2.norm()*r1r2.norm()) + r2r3 / (r2r3.norm()*r2r3.norm()*r2r3.norm());
        vector F3 = - r1r3 / (r1r2.norm()*r1r2.norm()*r1r2.norm()) - r2r3 / (r2r3.norm()*r2r3.norm()*r2r3.norm());
        return new vector($"{v1[0]},{v1[1]},{F1[0]},{F1[1]},{v2[0]},{v2[1]},{F2[0]},{F2[1]},{v3[0]},{v3[1]},{F3[0]},{F3[1]}");
    };
    static void Main(){
        //Example with u'' = -u
        vector ya = new vector($"0.0, 1.0");
        double N = 50;
        for(int i = 0; i<N; ++i){
            double x = 2*PI * i/N;
            vector y = ODE.driver(f,0,ya,x);
            WriteLine($"{x}, {y[0]}, {0}");
        }
   }    
}