all : gamma.pyxplot.png erf.pyxplot.png

gamma.pyxplot.png: gamma.data.txt gamma.log.gpi
	cat gamma.log.gpi | pyxplot

erf.pyxplot.png: erf.data.txt log.gpi
	cat log.gpi | pyxplot

#The & makes the two targets grouped i.e. make knows that the targets are produced every time the rule is executed.
erf.data.txt gamma.data.txt &: main.exe
	mono main.exe > erf.data.txt

%.exe: %.cs
	mcs $<

clean:
	rm -f erf.data.txt gamma.data.txt *.exe *.png

test: main.exe
	mono main.exe