using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
class main{
    static void Main(){
        matrix A = new matrix("2, 2, 3; 3, 0, 1");
        var QR = new QRGS(A);
        QR.Q.print();
        
   }
}