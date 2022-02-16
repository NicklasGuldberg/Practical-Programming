using System;
using static System.Math;
using static System.Console;
class MainClass{
    static void Main(){
        //quick testing of constructors
        vec r = new vec(1,2,3);
        WriteLine($"x = {r.x}, y = {r.y}, z = {r.z}");
        vec r2 = new vec(1,2);
        WriteLine($"x = {r2.x}, y = {r2.y}, z = {r2.z}");
        //Testing using the new print method
        r.print("r = ");
        r.print();
        r2.print("r2 = ");
        vec a = new vec(3,4,0);
        vec b = new vec(-1,6,0);
        //Tests the vector and dot product
        vec c = vec.cross(a,b); vec calt = a.cross(b);
        double n = vec.dot(a,b); double nalt = a.dot(b);
        a.print("a = ");
        b.print("b = ");
        c.print("The vector product of a and b is ");
        calt.print("The vector product of a and b is ");
        WriteLine($"The dot product of a and b is {n} = {nalt}");
        //Tests the norm
        double L = a.norm(); double Lalt = vec.norm(a);
        WriteLine($"The length of a is {L} = {Lalt}");
        WriteLine($"This should return true = {vec.approx(c,calt)}");
        WriteLine($"This should return false = {vec.approx(a,b)}");
    }
}