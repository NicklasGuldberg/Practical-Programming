using System;
using static System.Math;
using static System.Console;
class stdin{
        static void Main(){
                char[] delimiters = {' ','\t','\n',','};
                var options = StringSplitOptions.RemoveEmptyEntries; 
                for(string line = ReadLine(); line != null; line = ReadLine()){              
                        var words = line.Split(delimiters,options);
                        foreach(var word in words){
                                try{
		                        double x = double.Parse(word);
		                        WriteLine($"Input: {x} \t sin({x}) = {Sin(x)} \t cos({x})={Cos(x)}");
                                }
                                catch{
                                        WriteLine($"Input: {word} \t Error '{word}' is not a valid input");
                                }
                        }
                }      
        }
}