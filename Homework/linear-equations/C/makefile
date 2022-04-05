MATHDIR = ../../../MathLib
SHELL = /bin/bash #Bash is needed for {1..10} to work


plot.png : out.txt plot.gpi
	cat plot.gpi | pyxplot

# Format is E - real  U - user S - system
out.txt: #main.exe makefile
	# > out.txt
	for N in {5..600..5}; do\
		echo -n "$$N " >> out.txt;\
		/bin/time -f '%E %U %S' -a -o out.txt mono main.exe "$$N";\
	done

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll main.cs

matlib.dll: $(MATHDIR)/ode.cs $(MATHDIR)/vector.cs $(MATHDIR)/integrate.cs $(MATHDIR)/matrix.cs QR.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.txt *.exe *.dll *.png

