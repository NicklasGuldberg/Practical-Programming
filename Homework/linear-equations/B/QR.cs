using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 

public class QRGS{
    public matrix Q,R;
    public int n,m;
	public QRGS(matrix A){
        n = A.size1;
        m = A.size2;
        vector[] a = new vector[m]; // m is the number of vectors - not the size of each vector!
        vector[] q = new vector[m];     
        Q = new matrix(n,m);
        R = new matrix(n,m);
        for(int i = 0; i<m; ++i) a[i] = A[i];
        for(int i = 0; i<m; ++i){
            q[i] = a[i]/a[i].norm();
            for(int j=i+1; j<m; ++j){
                a[j] = a[j] - q[i]%a[j] * q[i];
            }
            Q[i] = q[i];
        R = Q.transpose()*A;
        }
    }
	public vector solve(vector b){
        if(!(n==m)) throw new Exception("Not a square matrix");
        vector c = Q.transpose()*b;
        matrix U = R; 
        vector y = new vector(n);
        double sum = 0;
        for(int i=n-1; i>=0; --i){
            sum = 0;
            for(int k = i + 1; k < n; ++k) sum += U[i,k] * y[k];
            y[i] = 1/U[i,i] * (c[i] - sum);
        }
        return y;
    }
    public matrix inverse(){
        var I = new matrix(n,n);
        I.set_unity();
        matrix Ainv = new matrix(n,n);
        for(int i = 0; i<n; ++i){
            Ainv[i] = this.solve(I[i]);
        }
        return Ainv;
    }
	// public matrix inverse(){/* return the inverse matrix (part B) */}
	// public double determinant(){/* return ΠiRii */}
}