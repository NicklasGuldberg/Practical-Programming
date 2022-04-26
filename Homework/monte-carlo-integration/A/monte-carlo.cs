using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static vector;
public static class MCintegrator{
    public static (double,double) plainmc(Func<vector,double> f, vector a, vector b, int N){
        // a and b are the vertices of the volume we are integrating over
        double V = 1;
        double sum2 = 0;
        double integral = 0;
        for(int i = 0; i < a.size; i++){
            V *= b[i] - a[i];
        }
        var rand = new Random();
        matrix x = new matrix(a.size,N);
        for(int i = 0; i< N; i++){
            for(int j = 0; j < a.size; j++){
                x[j,i] = a[j] + rand.NextDouble()*(b[j] - a[j]);
            }
            double fx = f(x[i]);
            integral += fx;
            sum2 += fx*fx;
        }
        // integral *= V/N;
        double err = V/Sqrt(N) * Sqrt(sum2/N - integral/N * integral/N);
        return (integral*V/N, err);
    }
}