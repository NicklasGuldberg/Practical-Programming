
import numpy as np
import scipy as sp
from scipy import integrate

i,j = 0,0
def f(x):
    global i
    i += 1
    return 1/np.sqrt(x)

def g(x):
    global j
    j += 1
    return np.log(x)/np.sqrt(x)

res = integrate.quad(f, 0, 1, epsabs = 0.001, epsrel=0.0001)
res2 = integrate.quad(g, 0, 1, epsabs = 0.001, epsrel=0.0001)
print("Scipy integrate.quad(1/sqrt(x)) = "+ str(res[0]) + ". It called the function " + str(i) + " times.")
print("Scipy integrate.quad(log(x)/sqrt(x)) = "+ str(res2[0]) + ". It called the function " + str(j) + " times.")