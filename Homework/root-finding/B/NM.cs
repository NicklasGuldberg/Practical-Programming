using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static vector;
//NM Is short for Newton's method
public static class NM{
    public static vector newton(Func<vector,vector> f, vector x0, double eps=1e-2){  
        vector x = x0.copy();
        int m = x0.size;
        int n = f(x0).size;
        matrix J = new matrix(n,m);
        vector dx = new vector(m);
        vector deltax = new vector(m);
        vector step, dxs;
        dx.set_zero();
        do {
            dxs = x * Pow(2,-26);
            for(int k = 0; k < m; ++k){
                dx[k] = dxs[k];
                for(int i = 0; i < n; ++i){
                    J[i,k] = (f(x   + dx)[i] - f(x)[i]) / dx[k];
                }
                dx[k] = 0;
            }
            var QR = new QRGS(J);
            deltax = QR.solve(-f(x));
            double lambda = 1;
            while( f(x + lambda*deltax).norm() > (1 - lambda/2.0) * f(x).norm() & lambda > 1.0/32 ){
                lambda *= 0.5;
            }
            x += lambda * deltax;
            step = lambda * deltax;
        } while(f(x).norm() > eps && step.norm() > dxs.norm() );
        return x;
    }
    // static matrix J(Func<vector,vector> f, vector x){
    //     int m = x.size;
    //     int n = f(x).size;

    // }
}