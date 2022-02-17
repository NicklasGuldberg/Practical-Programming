Out.txt : main.exe
	mono main.exe #> Out.txt   #Comment before > to make the output go to terminal instead of Out.txt

main.exe : main.cs vec.dll
	mcs main.cs -reference:vec.dll

vec.dll : vec.cs
	mcs -target:library vec.cs   #I omitted the -out as it seems redundant and no errors so far. Should inquire into this.
	
clean:
	rm -f Out.txt main.exe vec.dll