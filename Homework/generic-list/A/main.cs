using System;
using static System.Console;
using static System.Math;
//using static genlist<int>; //using may be unnecessary. 
class main{
    static void Main(){
        genlist<double[]> list = new genlist<double[]>(); //var can be used instead of genlist
        char[] delimiters = {' ','\t'};
        WriteLine();
        WriteLine("The numbers read from the stdinput written in exponential format are");
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(string line = ReadLine(); line != null; line = ReadLine()){              
            var words = line.Split(delimiters,options);
            double[] numbers = Array.ConvertAll(words, double.Parse);
            list.add(numbers); //list.data is now a jagged array.
            //WriteLine($"Current size of list is {list.Size}"); 
            //WriteLine($"Current capacity of list is {list.Capacity}");
        }
        
        for(int i=0; i<list.size; i++){
            var row = list.data[i];
            foreach(var number in row) Write($"{number:e} \t");
            Write("\n");
        }
        WriteLine();
    }
}