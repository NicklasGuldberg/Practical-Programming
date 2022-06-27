input = 1 2 3 4 5

out.txt : cmdline.exe
	mono cmdline.exe $(input) > out.txt
	cat out.txt

cmdline.exe : cmdline.cs
	mcs cmdline.cs

input.txt : 
	echo $(input) > input.txt

clean :
	rm -f *.txt *.exe