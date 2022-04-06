using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 

public class linfit{
    public vector c;
    public Func<double,double>[] F;
    public linfit(vector x, vector y, Func<double,double>[] fs, vector dy){
        int n = x.size;
        int m = fs.Length;
        F = fs;
        matrix A = new matrix(n,m);
        vector b = new vector(n);
        for(int i = 0; i<n; ++i){
            for(int j = 0; j<m; ++j){
                // WriteLine($"{i},{j}");
                A[i,j] = fs[j](x[i])/dy[i];
            }
            b[i] = y[i]/dy[i];
        }
        QRGS QR = new QRGS(A);
        c = QRGS.backsub(QR.R, QR.Q.transpose()*b);
    }
    public double f(double x){
        double sum = 0;
        for(int i = 0; i<F.Length; ++i){
            sum += c[i]*F[i](x);
        }
        return sum;
    }
    //constructor that takes double arrays
    // public linfit(double[] X, double[] Y, Func<double,double>[] f){
    //     vector x = new vector(X);
    //     vector y = new vector(Y);
    //     int n = x.size;
    //     int m = fs.Length;
    //     F = fs;
    //     WriteLine($"n = {n}, m = {m}");
    //     matrix A = new matrix(n,m);
    //     vector b = new vector(n);
    //     for(int i = 0; i<n; ++i){
    //         for(int j = 0; j<m; ++j){
    //             // WriteLine($"{i},{j}");
    //             A[i,j] = fs[j](x[i]);
    //         }
    //         b[i] = y[i];
    //     }
    //     QRGS QR = new QRGS(A);
    //     c = QRGS.backsub(QR.R, QR.Q.transpose()*b);
    // }
}