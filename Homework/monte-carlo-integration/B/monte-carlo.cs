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
    public static double corput(int n, int b=10){
        double q = 0;
        double bk = 1.0;
        while (n > 0){
            bk /= b;
            q += (n % b) * bk;
            n /= b;
        }
        return q;
    }
    public static void halton(int n, vector x){
        int[] b = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67}; 
        int d = x.size;
        if(d > b.Length) throw new Exception("Dimension higher than amount of bases (dimension too high)");
        for(int i = 0; i < d; ++i){
            x[i] = corput(n, b[i]);
        }
        
    }

    public static (double,double) haltonmc(Func<vector,double> f, vector a, vector b, int N){
        // a and b are the vertices of the volume we are integrating over
        double V = 1;
        double sum2 = 0;
        double integral = 0;
        double integralerr = 0;
        for(int i = 0; i < a.size; i++){
            V *= b[i] - a[i];
        }
        matrix x = new matrix(a.size,N);
        matrix xerr = new matrix(a.size,N);
        for(int i = 0; i< N; i++){
            halton(i,x[i]);
            halton(i+500,xerr[i]); //500 was chosen arbitrarily with no regard for anything
            for(int j = 0; j < a.size; j++){
                x[j,i] = a[j] + x[j,i]*(b[j] - a[j]);
                xerr[j,i] = a[j] + xerr[j,i]*(b[j] - a[j]);
            }
            integral += f(x[i]);
            integralerr += f(xerr[i]);

        }
        // integral *= V/N;
        return (integral*V/N, 2*Abs(integral*V/N - integralerr*V/N));
    }
}