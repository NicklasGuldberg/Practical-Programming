

Out.txt : main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library $^  #$^ is all dependents. Check 'automatic variables' for more. 

clean:
	rm -f Out.txt main.exe cmath.dll