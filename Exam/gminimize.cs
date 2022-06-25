using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
using static minimizer;
public static class GlobalMinimizer{


    public static (vector,vector,int) hmin(
        Func<vector,double> f, //The function we want to find the minimum of 
        vector v0, //Ranges for the sampling
        int N = 1000,
        double acc=0.0001 //Accuracy of the minimizer
    ){
        //Halton sequence sample then quasi-newton minimizer
        // Should in the end only return the position of the minimum
        int dim = v0.size/2;
        vector vmax = new vector(dim);
        vector vmin = new vector(dim);
        for(int i = 0; i<dim; ++i){
            vmax[i] = v0[2*i+1];
            vmin[i] = v0[2*i];
        }
        vector x = new vector(dim);
        // vector xp = new vector(dim); //previous x
        vector optstart = new vector(dim); //optimal start guess  - or at least the best one achieved from the sampling
        for(int i = 0; i<N; ++i){
            halton(i, x); //I made halton void in the monte-carlo homework. 
            for(int j = 0; j<dim; ++j){
                x[j] = x[j] * (vmax[j] - vmin[j]) + vmin[j];
            }
            if(i == 0){
                optstart = x.copy();
            } else{
                if(f(optstart)>f(x)){
                    WriteLine($"f(x) = {f(x)}, f(optstart) = {f(optstart)}");
                    optstart = x.copy(); 
                }
                // else WriteLine("Not better");
            }
            // We skip the first one as there is no comparison to be made.

            // WriteLine($"{x[0]}, {x[1]}"); //This allows me to test print the distribution of points.
            // xp = x.copy(); 
        }
        (vector res, int steps) = qnewton(f, optstart, acc);
        return (res,optstart, steps);
    }





}
