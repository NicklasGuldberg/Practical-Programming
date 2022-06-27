using System;
using System.Numerics;
using static System.Math;
using static System.Console;
using static cmath;

class main{

    static double gamma(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(x<0)return PI/Sin(PI*x)/gamma(1-x);
        if(x<9)return gamma(x+1)/x;
        double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return Exp(lngamma);
    }
    static double lngamma(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(x<0)return PI/Sin(PI*x)/gamma(1-x);
        if(x<9)return gamma(x+1)/x;
        double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return lngamma;
    }

    static void Main(){
        
        //Does the same for Gamma function
        var GammaDataWriter = new System.IO.StreamWriter("gamma.data.txt");
        double gammaxmin = -0.2; //Everything breaks if this is 0.
        double gammaxmax = 3.2;
        double gammaincrement = 1.0/20;
        for(double x=gammaxmin; x<=gammaxmax; x+=gammaincrement)
            GammaDataWriter.WriteLine($"{x}, {gamma(x+1)}"); //gamma(n+1)
        GammaDataWriter.Close();
        
        //I could not find tabulated values for the gamme functions so i print the values for integers instead.
        var GammaTabWriter = new System.IO.StreamWriter("gamma.tabdata.txt");
        for (var n=Ceiling(gammaxmin); n<gammaxmax; n+=1){
            int fact = 1;
            for (int i=1; i<= n; i++) fact *= i; //n!
            GammaTabWriter.WriteLine($"{n}, {fact}");
        }
        GammaTabWriter.Close();

        //lngamma
        var LnGammaDataWriter = new System.IO.StreamWriter("lngamma.data.txt");
        double lngammaxmin = 0.1; //Everything breaks if this is 0.
        double lngammaxmax =5;
        double lngammaincrement = 1.0/20;
        for(double x=lngammaxmin; x<=lngammaxmax; x+=lngammaincrement)
            LnGammaDataWriter.WriteLine($"{x}, {Log(gamma(x))}");
        LnGammaDataWriter.Close();
        
        var LnGammaTabWriter = new System.IO.StreamWriter("lngamma.tabdata.txt");
        for (var i=Ceiling(lngammaxmin); i<lngammaxmax; i+=1){
            int fact = 1;
            for (int n=1; n<= i-1; n++) fact *= n;
            LnGammaTabWriter.WriteLine($"{i}, {Log(fact)}");
        }
        LnGammaTabWriter.Close();

    }
}