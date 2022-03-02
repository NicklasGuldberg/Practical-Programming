using System;
using System.Numerics;
using static System.Math;
using static System.Console;
using static cmath;

class main{

    static double erf(double x){
        /// single precision error function (Abramowitz and Stegun, from Wikipedia)
        if(x<0) return -erf(-x); 
        double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
        double t=1/(1+0.3275911*x);
        double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
        return 1-sum*Exp(-x*x);
    }  
    
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
    static complex G(complex z){
        if(abs(z)<0)return PI/sin(PI*z)/G(1-z);
        if(abs(z)<9)return G(z+1)/z;
        var lngamma=z*log(z+1/(12*z-1/z/10))-z+log(2*PI/z)/2;
        return exp(lngamma);
    }

    static void Main(){
        
        double increment = 1.0/8;
        double xmin = -1;
        double xmax = 1;
        
        //Writes the erf approximation to standard output
        for(double x=xmin; x<=xmax; x+=increment)
            WriteLine($"{x},{erf(x)}");
        

        //Reads the tabulated data into a 2d-array tableplus[]
        string[] readText = System.IO.File.ReadAllLines("erf.table.txt");
        double[,] tableplus = new double[readText.Length,3];
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for (int i=0; i<readText.Length; i++){
            var line = readText[i].Split(delimiters,options);
            for(int j=0; j<3; j++){
                tableplus[i,j] = double.Parse(line[j]);
            }
        }
        //Adds the negative values
        double[,] tableminus = new double[tableplus.GetLength(0),3];
        double[,] table = new double[2*tableplus.GetLength(0),3];
        for (int i=0; i<tableplus.GetLength(0); i++){
            tableminus[i,1] = -tableplus[i,1];
            tableminus[i,0] = -tableplus[i,0];
            tableminus[i,2] = 1-tableplus[i,1];
            for (int j=0; j<3; j++){
                table[tableplus.GetLength(0)-1-i,j] = tableminus[i,j];
                table[i + tableplus.GetLength(0),j] = tableplus[i,j];
            }
        }

        //Prints the tabulated data in desired range to erf.tabdata.txt
        var Writer = new System.IO.StreamWriter("erf.tabdata.txt");
        for (int i= 0; i<table.GetLength(0); i++){
            if (table[i,0] > xmin & table[i,0] < xmax) Writer.WriteLine($"{table[i,0]},{table[i,1]},{table[i,2]}");
        }  
        Writer.Close();

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