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

        Func<vector,vector> F = delegate(vector v){
            double F1 = 2*v[0] + 400*v[0]*v[0]*v[0] - 400*v[0]*v[1] - 2;
            double F2 = 200 * (v[1] - v[0]*v[0]);
            vector result = new vector(F1,F2);
            return result;
        };
        vector Fx0 = new vector(5,5);
        vector Fx = newton(F,Fx0);

        WriteLine("\n");
        WriteLine("As a test we solve the simple system f(x,y) = [x^2 - 2y, y^2 - 3x] ");
        Write("The guess is ");
        x0.print("     x0  = ");
        Write("The solution is ");
        x.print("[x,y] = ");
        // WriteLine();
        WriteLine($"Inserting it back into the function gives us f(x,y) = [{f(x)[0]}, {f(x)[1]}] ");
        WriteLine();

        WriteLine("Now we find the extremum of f(x,y) = (1-x)^2 + 100(y - x^2)^2");
        WriteLine("The gradient is gradf(x,y) = (2x + 400x^3 - 400xy -2,  200(y-x^2)) ");
        Write("The guess is ");
        Fx0.print("     x0  =");
        Write("The solution is ");
        Fx.print("[x,y] =");
        WriteLine("According to wikipedia the correct minimum is (1,1)");
        WriteLine();
   }    
}