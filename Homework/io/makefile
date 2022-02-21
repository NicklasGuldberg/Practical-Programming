input = 1 2 3 4 5

out.txt : A
	cat out.txt

A : stdin.exe
	echo $(input) | mono stdin.exe > out.txt

stdin.exe : stdin.cs
	mcs stdin.cs

B : cmdline.exe
	mono cmdline.exe $(input) > out.txt

cmdline.exe : cmdline.cs
	mcs cmdline.cs

clean :
	rm -f out.txt *.exe