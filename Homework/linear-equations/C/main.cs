using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static void Main(string[] arg){
        int n = int.Parse(arg[0]);
        matrix A = QRGS.randomA(n,n);
        var I = new matrix(n,n);
        I.set_unity();
        // A.print();
        var QR = new QRGS(A);
        // vector b = new vector(n);
        // for(int i = 0; i < n; ++i){
        //     b[i] = rnd.Next(min,max);
        // }
   }    
}