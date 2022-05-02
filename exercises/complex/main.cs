using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
    static void Main(){
        //double a = - 1;
        //complex i = new complex(1,2);
        complex a = sqrt(new complex(-1,0));
        complex b = sqrt(I);
        complex c = exp(I);
        complex d = exp(I*PI);
        complex e = I.pow(I);
        complex f = log(I);
        complex g = sin(I*PI);
        complex h = sinh(I);
        complex i = cosh(I);
        WriteLine($"sqrt(-1) = {a}");
        WriteLine($"i = {a} is {a.approx(I)}");
        WriteLine($"sqrt(i) = {b}");
        WriteLine($"exp(i) = {c}");
        WriteLine($"exp(i*pi) = {d}");
        WriteLine($"-1 = {d} is {d.approx(-1)}");
        WriteLine($"i^i = {e}");
        WriteLine($"i^i = exp(- pi/2) is {e.approx(Exp(-PI/2.0))}");
        WriteLine($"log(i) = {f}");
        WriteLine($"log(i) = pi/2*i is {f.approx(PI/2.0 * I)}");
        WriteLine($"sin(i*pi) = {g}");
        WriteLine($"sin(i*pi) = i*sinh(pi) is {g.approx(I*Sinh(PI))}");
        // WriteLine($"sinh(i) = {h}");
        // WriteLine($"sinh(i) = i*sin(1) is {h.approx(I*sin(1))}");
        // WriteLine($"cosh(i) = {i}");

    }
}