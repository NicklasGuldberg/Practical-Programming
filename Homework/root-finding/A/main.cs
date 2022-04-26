using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static NM;
class main{
    static void Main(){
        Func<vector,vector> f= delegate(vector v){
            double f1 = v[0]*v[0] - 2* v[1];
            double f2 = v[1]*v[1] - 3* v[0];
            vector result = new vector(f1,f2);
            return result;
            //f(x,y) = (x^2 - 2y, y^2 - 3x) 
        };
        vector x0 = new vector(2,3);
        var x = newton(f,x0);
        WriteLine("\n");
        WriteLine("As a test we solve the simple system f(x,y) = [x^2 - 2y, y^2 - 3x] ");
        Write("The solution is  ");
        x.print("[x,y] = ");
        // WriteLine();
        WriteLine($"inserting it back into the function gives us f([x,y]) = [{f(x)[0]}, {f(x)[1]}] ");
        WriteLine();
   }    
}