all : gamma.pyxplot.png erf.pyxplot.png lngamma.pyxplot.png compgamma.pyxplot.png

gamma.pyxplot.png: gamma.data.txt gamma.log.gpi
	cat gamma.log.gpi | pyxplot

compgamma.pyxplot.png : compgamma.data.txt compgamma.log.gpi
	cat compgamma.log.gpi | pyxplot

lngamma.pyxplot.png: lngamma.data.txt lngamma.log.gpi
	cat lngamma.log.gpi | pyxplot

erf.pyxplot.png: erf.data.txt log.gpi
	cat log.gpi | pyxplot

#The & makes the two targets grouped i.e. make knows that the targets are produced every time the rule is executed.
erf.data.txt gamma.data.txt lngamma.data.txt &: main.exe
	mono main.exe > erf.data.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library $^

clean:
	rm -f erf.data.txt gamma.data.txt erf.tabdata.txt gamma.tabdata.txt lngamma.data.txt lngamma.tabdata.txt compgamma.data.txt *.exe *.png

test: main.exe
	mono main.exe