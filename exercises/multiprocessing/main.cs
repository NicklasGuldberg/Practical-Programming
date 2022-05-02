using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using System.Threading.Tasks;
using System.Threading;
class main{
    static void Main(string[] args){
        int N = (int) double.Parse(args[0]);
        double harmsum = 0; 
        // int N= (int)1e8;
        Action<int> S = delegate(int i){
            harmsum += 1.0/i;   
        };
        Parallel.For(1,N+1, S);     
        WriteLine("--------------------------------------------");
        WriteLine($"Parallel.For calculates harmonic sum from 1 to {N} = {harmsum}");
   }    
}