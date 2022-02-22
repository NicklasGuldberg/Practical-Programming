out.txt : main.exe
	cat input.txt | mono main.exe > out.txt
	cat out.txt

main.exe : main.cs genlist.dll
	mcs -reference:genlist.dll main.cs

genlist.dll : genlist.cs
	mcs -target:library genlist.cs

clean : 
	rm -f *.exe out.txt