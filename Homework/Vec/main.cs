using System;
using static System.Math;
using static System.Console;
class MainClass{
    static void Main(){
        vec r = new vec(1,2,3);
        Write($"x = {r.x}, y = {r.y}, z = {r.z}");
        vec r2 = new vec(1,2);
        Write($"x = {r2.x}, y = {r2.y}, z = {r2.z}");
    }
}