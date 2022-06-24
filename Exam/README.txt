Implement a stochastic global optimizer using the following algorithm,

    1.  Use the given number of seconds to search for the global minimum of the given
        function in the given volume by sampling the function using a low-discrepancy sequence.
    2.  From the best point found at the previous step run your quasi-newton minimizer. 




Algorithm 
    Generate points 'randomly' of the function using low-discrepancy sequence (pseudo-random is too uneven). 
    Use the best point as a guess for the quasi newton minimizer

    Is this all there isss???? 


Progress so far 
    I reused the Halton-sequence I made for monte-carlo part B. 