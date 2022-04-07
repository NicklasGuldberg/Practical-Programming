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
        Random rnd = new Random();
        var data = new System.IO.StreamWriter("data.txt");
        int n = 5;
        int N = 500;
        double[] t = new double[200];
        matrix A = randomsymA(n);

        // for(int i = 1; i<N; ++i){
        //     timesJ(A,2,3, rnd.Next(0,10));
        // }
        A.print("A =");
        // int p = 2;
        // int q = 1;
        // double theta = 0.5 * Atan2(2*A[p,q], A[q,q] - A[p,p]);         
        // WriteLine(theta);
        // Jtimes(A,p,q,-theta);
        // timesJ(A,p,q,theta);
        // A.print("A' = ");
        // WriteLine($"A'[p,q] = {A[p,q]}");
        // p= 3;
        // q = 1;
        // theta = 0.5 * Atan2(2*A[p,q], A[q,q] - A[p,p]);         
        // Jtimes(A,p,q,-theta);
        // timesJ(A,p,q,theta);//
        // A.print("A'' = "); 
        jcyclic(A);
        A.print("A' = ");
        data.Close();
   }    
}