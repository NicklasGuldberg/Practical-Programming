using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 

public class QRGS{
    public matrix Q,R;
    public int n,m;
    public static matrix randomA(int n=5, int m=5, int min = 0, int max= 10){
        Random rnd = new Random();
        matrix A = new matrix(n,m);
        for(int i = 0; i<n; i++){
            for(int j = 0; j<m; j++){
                A[i,j] = rnd.Next(min,max);
            }
        }
        return A;
    }
	public QRGS(matrix A){
        n = A.size1;
        m = A.size2;
        vector[] a = new vector[m]; // m is the number of vectors - not the size of each vector!
        vector[] q = new vector[m];     
        Q = new matrix(n,m);
        R = new matrix(m,m);
        for(int i = 0; i<m; ++i) a[i] = A[i];
        for(int i = 0; i<m; ++i){
            R[i,i] = a[i].norm();
            Q[i] = a[i]/R[i,i];
            for(int j=i+1; j<m; ++j){
                R[i,j] = Q[i]%a[j];
                a[j] = a[j] - R[i,j] * Q[i];
            }
        }
    }
	public vector solve(vector b){
        if(!(n==m)) throw new Exception("Not a square matrix");
        vector x = backsub(R, Q.transpose()*b);
        return x;
    }
    public static vector backsub(matrix U, vector c){
        vector y = new vector(c.size);
        double sum = 0;
        for(int i=c.size-1; i>=0; --i){
            sum = 0;
            for(int k = i + 1; k < c.size; ++k) sum += U[i,k] * y[k];
            y[i] = 1/U[i,i] * (c[i] - sum);
        }
        return y;
    }
    public matrix inverse(){
        var I = new matrix(m,m);
        I.set_unity();
        matrix Ainv = new matrix(m,n);
        for(int i = 0; i<n; ++i){
            Ainv[i] = this.solve(I[i]);
        }
        return Ainv;
    }
	// public matrix inverse(){/* return the inverse matrix (part B) */}
	// public double determinant(){/* return ΠiRii */}
}