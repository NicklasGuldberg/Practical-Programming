MATHDIR = ../../MathLib
erf.plot.png : erf.data.txt erf.plot.gpi
	cat erf.plot.gpi | pyxplot

erf.data.txt : main.exe
	mono main.exe > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/integrate.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll