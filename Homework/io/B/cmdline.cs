using System;
using static System.Math;
using static System.Console;
class cmdline{
    public static void Main(string[] args){
        foreach(var arg in args){
            try{
		        double x = double.Parse(arg);
		        WriteLine($"Input: {x} \t sin({x}) = {Sin(x)} \t cos({x})={Cos(x)}");
            }
            catch{
                WriteLine($"Input: {arg} \t Error '{arg}' is not a valid input");
            }
        }
    }
}