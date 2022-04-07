using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 

public static class eigenvalues{
    public static void timesJ(matrix A, int p, int q, double theta){
        int n = A.size1;
        // int m = A.size2;
        double s = Sin(theta);
        double c = Cos(theta);
        for(int i = 0; i<n; ++i){
            double Aip = A[i,p];
            double Aiq = A[i,q];
            A[i,p] = Aip*c - Aiq * s;
            A[i,q] = Aip*s + Aiq * c;
        }
    }
    public static void Jtimes(matrix A, int p, int q, double theta){
        int n = A.size1;
        // int m = A.size2;
        double s = Sin(theta);
        double c = Cos(theta);
        for(int i = 0; i<n; ++i){
            double Api = A[p,i];
            double Aqi = A[q,i]; 
            A[p,i] = Api*c + Aqi * s;
            A[q,i] = - Api*s + Aqi * c;
        }
    }
    public static void sweep(matrix A){
        for(int p = 0; p < A.size1; ++p){ 
            for(int q = p + 1; q < A.size1; ++q){
                double App = A[p,p];
                double Aqq = A[q,q];
                double Apq = A[p,q];
                double theta = 0.5*Atan2(2*Apq,Aqq-App);
                WriteLine($"{p}, {q}");
                Jtimes(A,p,q,-theta);
                timesJ(A,p,q,theta);
            }
        }
    }
    public static void jcyclic(matrix A){
        vector Diag1 = new vector(A.size1);
        vector Diag2 = new vector(A.size1);
        do
        {
        for(int i = 0; i< A.size1; ++i) Diag1[i] = A[i,i];
        sweep(A);
        for(int i = 0; i< A.size1; ++i) Diag2[i] = A[i,i];
        }
        while(!Diag1.approx(Diag2));
    }
}