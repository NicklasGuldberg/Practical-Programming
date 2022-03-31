MATHDIR = ../../MathLib

out.txt : main.exe
	mono main.exe > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll

