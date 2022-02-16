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
    public static vec operator+(vec u, vec v){
        return new vec(u.x + v.x, u.y + v.y, u.z + v.z);
    }
    public static vec operator-(vec u, vec v){
        return new vec(u.x - v.x, u.y - v.y, u.z - v.z);
    }
    public static vec operator-(vec u){
        return -1*u;
    }

    //dot product, vector product and norm
    public static double dot(vec u, vec v){
        return u.x*v.x + u.y*v.y + u.z*v.z;
    }
    public double dot(vec u){
        return u.x*this.x + u.y*this.y + u.z*this.z; //possibly could have used dot(this, u) instead.
    }
    public static vec cross(vec u, vec v){
        return new vec(u.y*v.z - u.z*v.y, u.z*v.x - u.x*v.z, u.x*v.y - u.y*v.z);
    }
    public vec cross(vec u){
        return cross(this,u);
    }
    public double norm(){
        return Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
    }
    public static double norm(vec u){
        return Sqrt(u.x*u.x + u.y*u.y + u.z*u.z);
    }

    //Methods
    public void print(string s){Write(s);WriteLine($"[{x}, {y}, {z}]");}
    public void print(){this.print("");}
    
    static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		double diff = Abs(a - b);
		double reldiff = diff/(Abs(a) + Abs(b));
		if (diff < tau)
			return true;
		else if (reldiff < epsilon)
			return true;
		else
			return false;
	}
    public static bool approx(vec u, vec v){
        if (approx(u.x,v.x) && approx(u.y,v.y) && approx(u.z,v.z))
            return true;
        else
            return false;
    }
    //The below yields a 'not all code paths return a value'-error
    /*
    public bool approx(vec u){
        approx(this, u);
    }     */    
}