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
        // Parallel.For(1,N+1, S); 
        long sum = 0;    
        // Parallel.For(1,N+1, i => sum += 1.0/i);     
        Parallel.For(1,N+1, i => Interlocked.Add(ref sum, (long) Floor(100000*N*1.0/i)));     
        harmsum = sum*1.0/(N*100000);
        // var a = (long) Floor(N*1.0/294738);
        // WriteLine($"test = {a} ");
        WriteLine("--------------------------------------------");
        WriteLine($"Parallel.For calculates harmonic sum from 1 to {N} = {harmsum}");
        WriteLine("This is wrong. The issue seems to be that Parallel tries to access sum in multiplethreads at the same time");
        WriteLine("To fix this I tried a version with Interlocked.");
        WriteLine("Interlocked.Add() however only accept integers and longs, so I scaled the number up and used Floor()");
        WriteLine("It still does not get it quite right and it is rather slow - I do not recommend 1.5/10");

   }    
}