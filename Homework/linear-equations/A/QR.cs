using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static matrix; 

public class QRGS{
    public matrix Q,R;
	public QRGS(matrix A){
        int n = A.size1;
        int m = A.size2;
        vector[] a = new vector[m]; // m is the number of vectors - not the size of each vector!
        vector[] q = new vector[m];     
        Q = new matrix(n,m);
        for(int i = 0; i<m; ++i) a[i] = A[i];
        for(int i = 0; i<m; ++i){
            q[i] = a[i]/a[i].norm();
            // for(int j=i+1; j<m; ++j){
            //     a[j] = a[j] - q[i]%a[j] * q[i];
            // }
            Q[i] = q[i];
        }
    }
	// public vector solve(vector b){/* back-substitute Q^T*b */}
	// public matrix inverse(){/* return the inverse matrix (part B) */}
	// public double determinant(){/* return ΠiRii */}
}