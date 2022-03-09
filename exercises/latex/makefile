
compile: latex.tex divplot.pdf testplot.pdf
	pdflatex latex.tex

latex.aux : latex.tex divplot.pdf testplot.pdf
	pdflatex latex.tex

divplot.pdf: divplot.gpi
	cat divplot.gpi| pyxplot
testplot.pdf : testplot.gpi  out.txt
	cat testplot.gpi | pyxplot

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs
	mcs main.cs

clean:
	rm -f latex.aux latex.dvi latex.log *.pdf *.txt *.exe