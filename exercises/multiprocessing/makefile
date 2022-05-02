MATHDIR = ../../MathLib

# plot.png : plot.gpi out.txt
	# cat plot.gpi | pyxplot

out.txt : main.exe t2.exe
	time -a -p -o $@ mono main.exe 5e8 > $@
	time -a -p -o $@ mono t2.exe 5e8 >> $@
	cat out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

t2.exe: t2.cs matlib.dll
	mcs -reference:matlib.dll t2.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs $(MATHDIR)/matrix.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll *.png

