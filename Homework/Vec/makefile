out.txt : vec.exe
	mono vec.exe > out.txt

vec.exe : vec.cs
	mcs vec.cs

clean:
	rm -f out.txt vec.exe

run:
	mono vec.exe