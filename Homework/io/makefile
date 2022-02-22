input = 1 2 3 4 5

out.txt : C
	#cat out.txt

A : stdin.exe
	echo $(input) | mono stdin.exe > out.txt

stdin.exe : stdin.cs
	mcs stdin.cs

B : cmdline.exe
	mono cmdline.exe $(input) > out.txt

cmdline.exe : cmdline.cs
	mcs cmdline.cs

C : fileio.exe input.txt
	mono fileio.exe -input:input.txt -output:out.txt

fileio.exe : fileio.cs
	mcs fileio.cs

input.txt : 
	echo $(input) > input.txt

clean :
	rm -f *.txt *.exe