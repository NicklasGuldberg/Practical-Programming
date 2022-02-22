using System;
using static System.Console;
using static System.Math;
//using static genlist<int>; //using may be unnecessary. 
class main{
    static void Main(){
        genlist<double[]> list = new genlist<double[]>(); //var can be used instead of genlist
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(string line = ReadLine(); line != null; line = ReadLine()){              
            var words = line.Split(delimiters,options);
            double[] numbers = Array.ConvertAll(words, double.Parse);
            list.push(numbers); //list.data is now a jagged array.
        }
        foreach(var row in list.data){ 
        /*foreach works here because it is a jagged array and not a 2d-array. 
        two for-loops (or one of each) works as well*/
            foreach(var number in row){
                Write($"{number} \t");
            }
            Write("\n");
        }
    }
}