using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static MCintegrator;
using static minimizer;
using System.Timers;
using System.Diagnostics;
public static class GlobalMinimizer{
    private static Timer aTimer;
    private static bool TimerShutoff;

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
                optstart = x.copy(); //We skip the first one as there is no comparison to be made.
            } else{
                if(f(optstart)>f(x)){
                    // WriteLine($"f(x) = {f(x)}, f(optstart) = {f(optstart)}");
                    optstart = x.copy(); 
                }
            }

            // WriteLine($"{x[0]}, {x[1]}, {f(x)}"); //This allows me to test print the distribution of points.
            // xp = x.copy(); 
        }
        (vector res, int steps) = qnewton(f, optstart, acc);
        return (res,optstart, steps);
    }

    private static void SetTimer(double seconds){
        int milliseconds = Convert.ToInt32(seconds*1000);
        aTimer = new System.Timers.Timer();
        aTimer.Interval = milliseconds;
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
    }
    public static (vector, vector, int, int) thmin(
        Func<vector,double> f, //The function we want to find the minimum of 
        vector v0, //Ranges for the sampling in the format
        double seconds = 2,
        double acc=0.0001 //Accuracy of the minimizer
    ){
        int dim = v0.size/2;
        vector vmax = new vector(dim);
        vector vmin = new vector(dim);
        vector x = new vector(dim);
        for(int j = 0; j<dim; ++j){
            vmax[j] = v0[2*j+1];
            vmin[j] = v0[2*j];
        }
        int i = 0;
        
        // Stopwatch stopWatch = new Stopwatch();
        // stopWatch.Start();

        TimerShutoff = true; //Resets the value so the function can be used again.
        SetTimer(seconds);
        vector optstart = new vector(dim); //optimal start guess  - or at least the best one achieved from the sampling
        while(TimerShutoff){
            halton(i, x); //I made halton void in the monte-carlo homework. 
            for(int j = 0; j<dim; ++j){
                x[j] = x[j] * (vmax[j] - vmin[j]) + vmin[j];
            }
            if(i == 0){
                optstart = x.copy(); //We skip the first one as there is no comparison to be made.
            } else{
                if(f(optstart)>f(x)){
                    // WriteLine($"f(x) = {f(x)}, f(optstart) = {f(optstart)}");
                    optstart = x.copy(); 
                }
            }
            ++i;
        }
        // stopWatch.Stop();
        int points = i + 1;

        // WriteLine($"{points} points were sampled from the Halton sequence");
        // optstart.print("optstart =");
        // WriteLine($"It took {stopWatch.Elapsed} seconds");
        (vector res, int steps) = qnewton(f, optstart, acc);
        return (res,optstart, steps, points);
    }
    private static void OnTimedEvent(Object source, ElapsedEventArgs e){
        TimerShutoff = false;
    }
}
