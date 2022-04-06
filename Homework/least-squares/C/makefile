MATHDIR = ../../../MathLib

plot.png : plot.gpi data.txt
	cat plot.gpi | pyxplot

data.txt : main.exe
	mono main.exe > out.txt
	cat out.txt 

out.txt : main.exe
	mono main.exe > $@
	cat out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs $(MATHDIR)/matrix.cs $(MATHDIR)/QR.cs fit.cs 
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll

