using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        double b = 0.25;
        double c = 5.0;
        Func<double, vector, vector> F = delegate(double t, vector y){
            double theta = y[0];
            double omega = y[1];
            var dydt = new vector(omega, - b*omega - c*Sin(theta));
            return dydt;
        };
        vector y0 = new vector(PI - 0.1, 0.0);
        double tstart = 0;
        double tstop = 10;
        var tlist = new List<double>();
        var ylist = new List<vector>();
        ode.ivp(F,tstart,y0,tstop,tlist,ylist);

        for(int i=0; i<tlist.Count;i++)
            WriteLine($"{tlist[i]}, {ylist[i][0]}, {ylist[i][1]}");
    }
}