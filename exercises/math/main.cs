using static System.Console;
using static System.Math;

class math{
	static void Main(){
		double sqrt2 = Sqrt(2.0);
		double epi = Pow(E, PI);
		double pie = Pow(PI, E);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"Test of sqrt(2): 2 = {sqrt2*sqrt2}\n");
		Write($"e^pi = {epi}\n");
		Write($"test for e^pi: 1 = {Pow(epi,1/PI)/E}\n");
		Write($"pi^e = {pie}\n");
		Write($"test for pi^e: 1 = {Pow(pie,1/E)/PI}\n");
	}

}
