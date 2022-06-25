MATHDIR = ../MathLib

#  plot.png : plot.gpi out.txt
	# cat plot.gpi | pyxplot

out.txt : main.exe
	mono main.exe > $@
	cat out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs $(MATHDIR)/matrix.cs monte-carlo.cs minimize.cs gminimize.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll *.png

