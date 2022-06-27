compgamma.pyxplot.png : compgamma.data.txt compgamma.log.gpi
	cat compgamma.log.gpi | pyxplot

#The & makes the two targets grouped i.e. make knows that the targets are produced every time the rule is executed.
compgamma.data.txt &: main.exe
	mono main.exe > erf.data.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library $^

clean:
	rm -f erf.data.txt gamma.data.txt erf.tabdata.txt gamma.tabdata.txt lngamma.data.txt lngamma.tabdata.txt compgamma.data.txt *.exe *.png
