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
        int n = 5;
        // int N = 500;
        // double[] t = new double[200];
        matrix I = id(n);
        matrix D = randomsymA(n);
        matrix A = D.copy();
        matrix V = I.copy();
        jcyclic(D,V);
        A.print("A = ");
        D.print("D = ");
        V.print("V = ");
        WriteLine($"V^T * A * V = D : {D.approx(V.transpose()*A*V)}");
        WriteLine($"V * D * V^T = A : {A.approx(V*D*V.transpose())}");
        WriteLine($"V^T * V = I : {I.approx(V.transpose()*V)}");
        WriteLine($"V * V^T = I : {I.approx(V*V.transpose())}");
        WriteLine($"A * V[0] = D[0,0] V[0]: {(D[0,0] * V[0]).approx(A*V[0])}");
        // data.Close();
        var AV = A*V[0];
        AV.print();
        var DV = D[0,0] * V[0];
        DV.print();
   }    
}