out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs table.dll
	mcs -reference:table.dll main.cs

table.dll : table.cs
	mcs -target:library table.cs

clean :
	rm -f *.dll *.txt *.exe