Out.txt : main.exe
	mono main.exe #> Out.txt   #Comment before > to make the output go to terminal instead of Out.txt

main.exe : main.cs vec.dll
	mcs main.cs -reference:vec.dll

vec.dll : vec.cs
	mcs -target:library vec.cs
	
clean:
	rm -f Out.txt main.exe vec.dll