MATHDIR = ../../../MathLib

# plot.png : plot.gpi out.txt
	# cat plot.gpi | pyxplot

out.txt : main.exe python.py
	mono main.exe > $@
	python3 python.py >> $@
	cat out.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/vector.cs $(MATHDIR)/matrix.cs integrate.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll *.png

