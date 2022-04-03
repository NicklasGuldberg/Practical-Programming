MATHDIR = ../../../MathLib

# plot.png : out.txt plot.gpi
# 	cat plot.gpi | pyxplot

out.txt : main.exe
	mono main.exe > $@
	cat out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs $(MATHDIR)/matrix.cs QR.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll *.png

