using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static void Main(){
        int n = 5;
        int m = 5;
        int min = 0;
        int max = 10;
        Random rnd = new Random();
        matrix A = new matrix(n,m);
        for(int i = 0; i<n; i++){
            for(int j = 0; j<m; j++){
                A[i,j] = rnd.Next(min,max);
            }
        }
        var I = new matrix(m,m);
        I.set_unity();
        var QR = new QRGS(A);
        Write("R =");
        QR.R.print();
        Write("Q =");
        QR.Q.print();
        var B = QR.Q.transpose()*QR.Q;
        B.print();
        WriteLine($"Q^T * Q = 1: {I.approx(QR.Q.transpose()*QR.Q)}");
        WriteLine($"Q * R = A: {A.approx(QR.Q * QR.R)}");
        vector b = new vector(n);
        for(int i = 0; i < n; ++i){
            b[i] = rnd.Next(min,max);
        }
        vector x = QR.solve(b);
        WriteLine($"A * x = b: {b.approx(A*x)}");
        
   }    
}