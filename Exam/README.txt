Name: Nicklas Haislund Guldberg
Student number: 201707104
Examination project 4:
    Yet another stochastic global optimizer

    Implement a stochastic global optimizer using the following algorithm,

        Use the given number of seconds to search for the global minimum of the given function in the given volume by sampling the function using a low-discrepancy sequence.
        From the best point found at the previous step run your quasi-newton minimizer. 

For this project I implemented a method thmin()  (see gminimize.cs), which takes 4 arguments: a function to be minimized, a vector containing the boundaries of the volume, a double with the amount of seconds to run the sampling in, and the desired accuracy. The method return the approximate coordinate of the minimum of the function, the best point found when sampling the function, the amount steps taken by the quasi newton minimizer and how many points sampled. 

The method start by setting a timer for the desired time in seconds. It then uses the low discrepancy Halton sequence (reused from monte-carlo homework) to sample the function. It then compares the function value with smallest function value found yet and records the smallest one in the optstart variable. When the timer triggers the sampling is stopped and the sample size is recorded. Finally, the optstart variable is used as a start guess for the quasi-newton minimizer (reused from minimization homework).  

In addition I implemented a method where the desired number of points is specified instead of the number of seconds used.

The method thmin() is then tested on 4 functions taken from https://en.wikipedia.org/wiki/Test_functions_for_optimization. The result is then compared to using a specified start guess for the quasi-newton minimizer. The minima found are all reasonably close to the actual minima, and there is a significant reduction in steps taken by the quasi-newton minimizer. 

The advantage of using a low discrepancy sequence for the sampling, rather than random sampling, is that the low discrepancy sequence is more consistent. The probability of missing features by having a 'bald spot' is less when sampling is evenly spread over the volume. 
