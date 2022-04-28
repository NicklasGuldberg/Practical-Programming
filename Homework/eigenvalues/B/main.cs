using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;
using static System.Math;
using static matrix;
using static eigenvalues;
class main{
    static (matrix,matrix) Hmatrix(double rmax = 10, double dr = 0.3){

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
        return (H,V);
    }
    static double Emin(double rmax = 10, double dr = 0.3){
        matrix H,V;
        (H,V) = Hmatrix(rmax, dr);
        double E = 100;
        for(int i = 0; i<H.size1; ++i){
            E = Min(E,H[i,i]);
        }
        return E;
    }        

    static void Main(){
        
        // matrix H = Hmatrix();
        // vector E = new vector(H.size1);
        // double Emin = 0;
        // for(int i = 0; i < E.size; ++i){
        //     E[i] = H[i,i];
        //     Emin = Min(Emin, E[i]);
        // }
        // WriteLine("\n");
        // WriteLine($"Emin = {Emin}");
        // WriteLine("");
        var data = new System.IO.StreamWriter("data.txt");
        for(double rmax = 1.4; rmax < 8; rmax += 0.2){
            data.WriteLine($"{rmax}, {Emin(rmax)}, {Emin(rmax,0.1)}, {Emin(rmax,0.5)}, {Emin(rmax,0.7)}");
        }
        data.WriteLine("\n");
        for(double dr = 0.1; dr < 3.0; dr += 0.1){
            data.WriteLine($"{dr}, {Emin(6, dr)}, {Emin(7, dr)}, {Emin(8, dr)}, {Emin(10, dr)}");
        }
        data.WriteLine("\n");


        //This is supposed to be the wave functions
        {
        double dr = 0.1;
        double rmax = 40;
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
        for(int i = 0; i < r.size; ++i){
            data.WriteLine($"{r[i]}, {V[i,0]/Sqrt(dr)}, {-V[i,1]/Sqrt(dr)}, {V[i,2]/Sqrt(dr)}");
        }
        data.WriteLine("\n");
        for(double x = 0; x < rmax; x += 0.05){
            data.WriteLine($"{x}, {2*x*Exp(-x)}, {1/Sqrt(2)*x*(1-0.5*x)*Exp(-0.5*x)}, {x*2.0/Sqrt(27)*(1 - 2.0/3*x + 2.0/27 *x*x)*Exp(-x/3.0)}");
        }
        // 1.0/Sqrt(24)*x*Exp(-x/2.0)
        // x*2.0/Sqrt(27)*(1 - 2.0/3 + 2.0/27 *x*x)*Exp(-x/3.0)
        // H.print();
        data.Close();
        }
        
   }    
}