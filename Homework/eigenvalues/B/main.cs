using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;
using static System.Math;
using static matrix;
using static eigenvalues;
class main{
    static void Main(){
        // Stopwatch time = new Stopwatch();
        // Random rnd = new Random();
        // var data = new System.IO.StreamWriter("data.txt");
        // int n = 5;
        // int N = 500;
        // double[] t = new double[200];
        double rmax=10,dr=0.3;
        int npoints = (int)(rmax/dr)-1;
        vector r = new vector(npoints);
        for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
        matrix H = new matrix(npoints,npoints);
        for(int i=0;i<npoints-1;i++){
        matrix.set(H,i,i,-2);
        matrix.set(H,i,i+1,1);
        matrix.set(H,i+1,i,1);
        }
        matrix.set(H,npoints-1,npoints-1,-2);
        H*=-0.5/dr/dr;
        for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
        
        matrix V = id(npoints);
        jcyclic(H,V);
   }    
}