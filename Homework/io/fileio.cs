using System;
using static System.Console;
using static System.Math;
class fileio{
    public static void Main(string[] args){
        string infile, outfile; 
        infile = outfile = null; //We need to assign the variables so the compiler doesn't see them as unassigned.
        foreach(var arg in args){
            var str = arg.Split(':');
            if (str[0] == "-input") infile = str[1];
            else if (str[0] == "-output") outfile = str[1];
            else {Error.WriteLine($"{str[0]} is an invalid argument");}
        }
        var Reader = new System.IO.StreamReader(infile);
        var Writer = new System.IO.StreamWriter(outfile);
        char[] delimiters = {' ','\t','\n',','};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for (string line = Reader.ReadLine(); line != null; line = Reader.ReadLine()){
            var words = line.Split(delimiters,options);
                foreach(var word in words){
                    try{
	                    double x = double.Parse(word);
                        Writer.WriteLine($"Input: {x} \t sin({x}) = {Sin(x)} \t cos({x})={Cos(x)}");
                    }
                    catch{
                        Writer.WriteLine($"Input: {word} \t Error '{word}' is not a valid input");
                    }
                }
        }
        //Reader.Close(); //Not necessary
        //Writer.Flush(); //This works just as well
        Writer.Close();
    }
}