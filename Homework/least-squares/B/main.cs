using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static void Main(){
        int n = 10;
        int m = 5;
        matrix A = randomA(n,m);
        vector b = new vector("1, 1, 1, 1, 1, 1, 1, 1, 1, 1");
        var I = new matrix(5,5);
        I.set_unity();
        var QR = new QRGS(A);
        WriteLine($"Q^T * Q = 1: {I.approx(QR.Q.transpose()*QR.Q)}");
        WriteLine($"Q * R = A: {A.approx(QR.Q * QR.R)}");
        var fs = new Func<double,double>[] { z => 1.0, z=> - z}; 
        vector x = new vector("1,  2,  3, 4, 6, 9, 10, 13, 15");
        vector y = new vector("117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1");
        vector dy = new vector("5, 5, 5, 5, 5, 1, 1, 1, 1");
        vector lny = new vector(y.size);
        vector dlny = new vector(dy.size);
        for(int i = 0; i<y.size; ++i){
            lny[i] = Log(y[i]);
            dlny[i] = dy[i]/y[i];
        }
        var fit = new linfit(x,lny,fs,dlny);
        fit.c.print("c =");
        WriteLine($"The lifetime of ThX as determined by the fit is: t½ = {Log(2)/fit.c[1]} days");
        WriteLine("According to wikipedia ThX (Ra-224) has half life of: t½ = 3.6319");

        var data = new System.IO.StreamWriter("data.txt");
        for(int i = 0; i<x.size; ++i){
            data.WriteLine($"{x[i]} {y[i]} {dy[i]}");
        }
        data.WriteLine();
        data.WriteLine();

        for(double xs = 0; xs<16; xs += 0.1){
            data.WriteLine($"{xs} {Exp(fit.f(xs))} {0}");
        }
        
        data.Close();
        fit.Cov.print();
   }    
}