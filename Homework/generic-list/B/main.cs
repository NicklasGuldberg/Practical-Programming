using System;
using static System.Console;
using static System.Math;
//using static genlist<int>; //using may be unnecessary. 
class main{
    static void Main(){
        genlist<double[]> list = new genlist<double[]>(); //var can be used instead of genlist
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        WriteLine();
        WriteLine("The numbers read from the stdinput written in exponential format are");
        for(string line = ReadLine(); line != null; line = ReadLine()){              
            var words = line.Split(delimiters,options);
            double[] numbers = Array.ConvertAll(words, double.Parse);
            list.push(numbers); //list.data is now a jagged array.
            //WriteLine($"Current size of list is {list.Size}"); 
            //WriteLine($"Current capacity of list is {list.Capacity}");
        }
        /*
        foreach(var row in list.data){ 
        //foreach works here because it is a jagged array and not a 2d-array. Two for-loops (or one of each) works as well
        //This gives an ugly unhandled exception after using capacity in genlist.cs
            foreach(var number in row){
                Write($"{number} \t");
            }
            Write("\n");
        }
        */
        
        for(int i=0; i<list.Size; i++){
            var row = list.data[i];
            foreach(var number in row) Write($"{number:e} \t");
            Write("\n");
        }
        WriteLine();
    }
}