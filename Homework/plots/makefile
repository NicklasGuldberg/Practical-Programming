all : gamma.pyxplot.png erf.pyxplot.png

gamma.pyxplot.png: gamma.data.txt gamma.log.gpi
	cat gamma.log.gpi | pyxplot

erf.pyxplot.png: erf.data.txt log.gpi
	cat log.gpi | pyxplot

erf.data.txt : main.exe
	mono main.exe > erf.data.txt

%.exe: %.cs
	mcs $<

clean:
	rm -f erf.data.txt *.exe *.png

test: main.exe
	mono main.exe