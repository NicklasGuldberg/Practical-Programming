input = 1 2 3 4 5


out.txt : stdin.exe
	echo $(input) | mono stdin.exe > out.txt
	cat out.txt
	
stdin.exe : stdin.cs
	mcs stdin.cs

clean :
	rm -f *.txt *.exe