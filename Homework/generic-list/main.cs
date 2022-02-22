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
            list.push(numbers); //list.data is now a 2d array with numbers being each row.
        }
        for(int i = 0; i<list.size; i++){
            foreach(var number in list.data[i]){
                Write($"{number:e} \t");
            }
            Write("\n");
        }
    }
}