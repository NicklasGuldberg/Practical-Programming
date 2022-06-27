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

    }
}