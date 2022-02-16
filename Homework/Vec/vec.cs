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

    //operators:
    public static vec operator*(vec v, double c){return new vec(c*v.x,c*v.y,c*v.z);}
    public static vec operator*(double c, vec v){return v*c;}
    public static vec operator+(vec u, vec v){/*...*/}
    public static vec operator-(vec u, vec v){/*...*/}
    public static vec operator-(vec u){/*...*/}
}