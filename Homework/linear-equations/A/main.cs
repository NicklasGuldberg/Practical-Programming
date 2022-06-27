using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static void Main(){
        int n = 5;
        int m = 8;
        int min = 0;
        int max = 10;
        Random rnd = new Random();
        var I = new matrix(n,n);
        I.set_unity();


        matrix A1 = new matrix(m,n);
        for(int i = 0; i<m; i++){
            for(int j = 0; j<n; j++){
                A1[i,j] = rnd.Next(min,max);
            }
        }
        var QR1 = new QRGS(A1);
        WriteLine();
        WriteLine("First we test the tall matrix");
        WriteLine("In the interest of not printing the same matrix multiple times the approx() function is used for testing");
        WriteLine("A =");
        A1.print();
        Write("Q =");
        QR1.Q.print();
        Write("R =");
        QR1.R.print();
        WriteLine($"Q^T * Q = 1: {I.approx(QR1.Q.transpose()*QR1.Q)}");
        WriteLine($"Q * R = A: {A1.approx(QR1.Q * QR1.R)}");

        WriteLine();
        WriteLine("Now for the square matrix");
        matrix A = new matrix(n,n);
        for(int i = 0; i<n; i++){
            for(int j = 0; j<n; j++){
                A[i,j] = rnd.Next(min,max);
            }
        }
        var QR = new QRGS(A);
        vector b = new vector(n);
        for(int i = 0; i < n; ++i){
            b[i] = rnd.Next(min,max);
        }
        vector x = QR.solve(b);
        Write("A =");
        A.print();
        Write("Q =");
        QR.Q.print();
        Write("R =");
        QR.R.print();
        Write("b =");
        b.print();
        WriteLine("Solving for Q*R x=b for x yields");
        Write("x =");
        x.print();
        WriteLine($"Q * R = A: {A.approx(QR.Q * QR.R)}");
        WriteLine($"A * x = b: {b.approx(A*x)}");
   }    
}