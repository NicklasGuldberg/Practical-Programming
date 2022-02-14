using static System.Console;
using static System.Math;

class epsilon{
	static void Main(){
		int i=1; while(i+1>i) {i++;}
		Write($"Maximum representable integer is {i}\n");
		Write($"int.MaxValue is {int.MaxValue}\n");
	}
}
