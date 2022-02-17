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
        WriteLine($"log(i) = {f}");
        WriteLine($"sin(i*pi) = {g}");
        WriteLine($"sinh(i) = {h}");
        WriteLine($"cosh(i) = {i}");

    }
}