using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;
using static System.Math;
using static matrix;
using static eigenvalues;
class main{
    static void Main(){
        Stopwatch time = new Stopwatch();
        // Random rnd = new Random();
        // var data = new System.IO.StreamWriter("data.txt");
        
        int N = 350;
        double[] t = new double[N];

        for(int i = 5; i<N+1; i+=5){
            matrix A = randomsymA(i);
            time.Start();
            jcyclic(A);
            time.Stop();
            WriteLine($"{i} {time.ElapsedMilliseconds}");
            time.Reset();
        }

        WriteLine();
        WriteLine();

        for(int i = 5; i<N+1; i+=5){
            matrix A = randomsymA(i);
            time.Start();
            optjcyclic(A);
            time.Stop();
            WriteLine($"{i} {time.ElapsedMilliseconds}");
            time.Reset();
        }
        // data.Close();
        // matrix D = randomsymA(n);
        // matrix A = D.copy();
        // matrix V = I.copy();
        // jcyclic(D,V);
        // data.Close();
        // var AV = A*V[0];
        // AV.print();
        // var DV = D[0,0] * V[0];
        // DV.print();
   }    
}