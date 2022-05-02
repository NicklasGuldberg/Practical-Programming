using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using System.Threading.Tasks;
using System.Threading;
class main{
    public class data{
        public int a;
        public int b;
        public double sum;
    }
    public static void harmonic_sum(object obj){
        data x = (data)obj;
        x.sum = 0;
        for(int i = x.a; i < x.b+1; ++i){
            x.sum += 1.0/i;
        }
    }
    static void Main(string[] args){
        int N = (int) double.Parse(args[0]);
        data x1 = new data();
        data x2 = new data();
        x1.a = 1; 
        x1.b = N/2;
        x2.a = x1.b + 1; 
        x2.b = N;
        Thread t1 = new Thread(harmonic_sum);
        Thread t2 = new Thread(harmonic_sum);
        t1.Start(x1);
        t2.Start(x2);
        t1.Join();
        t2.Join();
        WriteLine("--------------------------------------------");
        WriteLine($"Thread 1 calculates harmonic sum from {x1.a} to {x1.b} = {x1.sum}");
        WriteLine($"Thread 2 calculates harmonic sum from {x2.a} to {x2.b} = {x2.sum}");
        WriteLine($"Total harmonic sum from 1 to {N} = {x1.sum + x2.sum}");  
   }    
}