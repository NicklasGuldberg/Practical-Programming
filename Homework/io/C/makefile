input = 1 2 3 4 5

out.txt : fileio.exe input.txt
	mono fileio.exe -input:input.txt -output:out.txt

fileio.exe : fileio.cs
	mcs fileio.cs

input.txt : 
	echo $(input) > input.txt

clean :
	rm -f *.txt *.exe