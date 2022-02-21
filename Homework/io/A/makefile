out.txt : stdin.exe
	echo 1 2 3 4 5 | mono stdin.exe > out.txt
	cat out.txt

stdin.exe : stdin.cs
	mcs stdin.cs

clean :
	rm -f out.txt stdin.exe