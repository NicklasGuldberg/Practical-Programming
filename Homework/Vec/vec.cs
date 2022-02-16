using static System.Math;
using static System.Console;
public class vec{
    public double x,y,z;
    //constructors:
    public vec(){x=y=z=0;}
    public vec(double a, double b){
        x=a; y=b; z=0;
    }       // I added a 2 argument constructor for vectors in the z-plane. 
    public vec(double a, double b, double c){
        x=a; y=b; z=c;
    }

    
}