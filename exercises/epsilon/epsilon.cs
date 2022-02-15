using static System.Console;
using static System.Math;

class epsilon{
	static void Main(){
		int i=1; while(i+1>i) {i++;}
		Write($"Maximum representable integer is {i}\n");
		Write($"int.MaxValue is {int.MaxValue}\n");
		
		int j=1; while(j-1<j) {j--;}
		Write($"Minimum representable integer is {j}\n");
		Write($"int.MinValue is {int.MinValue}\n"); 

		double x=1; while(1+x!=1){x/=2;} x*=2;
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		WriteLine($"The machine epsilon for doubles is {x}");
		WriteLine($"compared to 2^(-52) = {Pow(2,-52)}");
		WriteLine($"The machine epsilon for floats is {y}");
		WriteLine($"compared to 2^(-23) = {Pow(2,-23)}");
		double epsilon = x;
		double tiny = epsilon/2;
		double sumA1 = 1 + tiny + tiny + tiny + tiny;
		double sumB1 = tiny + tiny + tiny + tiny + 1;
		WriteLine($"sumA - 1 = {sumA1-1}");
		WriteLine($"sumB - 1 = {sumB1-1}");
		
		int n=(int)1e6;			//(int) converts the double 1e6 to an integer - cannot be left out
		double sumA=0,sumB=0;

		sumA+=1; for(int k=0;k<n;k++){sumA+=tiny;}  //initially i = 0. i<n is the condition for the code block ({sumA+=tiny;}). i++ is what to do after every code block.
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}"); 

		for(int k=0;k<n;k++){sumB+=tiny;} sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
		/*	The machine epsilon is the smallest number the machine is able to add to 1. 
			Tiny is less than epsilon and as such 1 + tiny = 1. 
			This should be obvious from the way we constructed epsilon
		*/
	}
}