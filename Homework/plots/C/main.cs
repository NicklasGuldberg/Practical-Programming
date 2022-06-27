using System;
using System.Numerics;
using static System.Math;
using static System.Console;
using static cmath;

class main{

    static complex G(complex z){
        if(abs(z)<0)return PI/sin(PI*z)/G(1-z);
        if(abs(z)<9)return G(z+1)/z;
        var lngamma=z*log(z+1/(12*z-1/z/10))-z+log(2*PI/z)/2;
        return exp(lngamma);
    }

    static void Main(){

        //complex gamma function
        var CompGammaDataWriter = new System.IO.StreamWriter("compgamma.data.txt");
        double compmin = -4.9;
        double compmax = 4.9;
        double compincrement = 0.06;
        for (double x = compmin; x<= compmax; x+= compincrement){
            for (double y = compmin; y<= compmax; y+= compincrement){
                complex z = new complex(x,y);
                CompGammaDataWriter.WriteLine($"{x}, {y}, {abs(G(z))}");
            }
        }
        CompGammaDataWriter.Close();

    }
}