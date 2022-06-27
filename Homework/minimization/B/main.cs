using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix;
using static minimizer;
class main{
	public double A = 1;
    static void Main(){
	Func<vector, double> F = delegate(vector v){
		double A = v[0];
		double E = v[1];
		double m = v[2];
		double Gamma = v[3];
		return A/((E - m)*(E-m) + Gamma*Gamma/4);
	};
	var energy = new List<double>();
	var sigma = new List<double>();
	var DeltaSigma  = new List<double>();
	var separators = new char[] {' ','\t'};
	var options = StringSplitOptions.RemoveEmptyEntries;
	do{
			string line=Console.In.ReadLine();
			if(line==null)break;
			string[] words=line.Split(separators,options);
			energy.Add(double.Parse(words[0]));
			sigma.Add(double.Parse(words[1]));
			DeltaSigma.Add(double.Parse(words[2]));
	}while(true);

	Func<vector, double> D = delegate(vector v){
		double m = v[0];
		double Gamma = v[1];
		double A = v[2];
		double sum = 0;
		vector w = new vector(4);
		w[0] = A;
		w[2] = m;
		w[3] = Gamma;
		for(int i = 0; i< energy.Count; ++i){
			w[1] = energy[i];
			sum += ((F(w) - sigma[i])/DeltaSigma[i]) * ((F(w) - sigma[i])/DeltaSigma[i]);
		}
		return sum;
	};
	vector v0 = new vector(100, 1, 5);
	var (vmin,steps) = qnewton(D,v0,0.0001);
	// vmin.print("vmin =");
	// WriteLine($"{steps}");
	vector u = new vector(4);
	u[0] = vmin[2]; //A
	u[2] = vmin[0]; //m
	u[3] = vmin[1]; //Gamma
	for(double E = 100; E < 160; E+=0.1){
		u[1] = E;
		WriteLine($"{E}, {F(u)}");
	}
   }    
}
