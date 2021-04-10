# ProblemGeneratorApp-C-

Scurta documentatie
Scop: crearea unui program care sa genereze un numar cerut de probleme cu cerinte asemanatoare, dar cu exemple numerice diferite.

Clase folosite: 
	ProblemType1, ProblemType2, ProblemType3, ...
o	reprezinta modelul unei probleme pe care dorim sa o generam
o	membrii ei reprezinta variabilele care vor fi injectate in textul problemei dupa generare
o	membrii ei sunt (deocamdata) de 3 tipuri:
	CustomProperty
	CustomPropertyRangeAsList
	string ProblemText (textul propriu-zis al problemei)
	CustomProperty
o	retine valoarea care urmeaza sa fie injectata si Range-ul din care se alege aceasta valoare [MinValue, MaxValue]
	CustomPropertRangeAsList
o	retine valoarea care urmeaza sa fie injectata si Range-ul din care se alege sub forma de lista (ex. alegerea numelui functiei List = {“f”, “g”, “h”}
	GeneratorEngine
o	o clasa statica, generica care parseaza dinamic toate proprietatile obiectului generic transmis, populeaza membrii care urmeaza sa fie injectati in textul problemei respectand range-urile si creeaza textul problemei, injectand toate variabilele.
o	poate fi apelata o metoda de creare a unui numar specific de probleme, care vor fi intoarse prin intermediul unei liste cu elemente de tipul ProblemType1, ProblemType2, continand textele problemelor si variabilele generate etc

AVANTAJE: Pentru mentinere/adaugare de probleme, este necesara doar adaugarea in proiect a unei clase ProblemTypeN, care sa contina variabile de tipul CustomProperty sau CustomPropertyRangeAsList pentru inlocuirea automata a {0}, {1}, {2}, ... si stringul cu textul problemei de forma: 
“Introdu text aici-->{0}<-- si aici -->{1}<-- si aici -->{2}<--“
EXEMPLU OUTPUT: pentru stringul "Subprogramul {0} este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de {3} ori. \n" +
"void {0} (int x){{\n" +
"  cout << \"*\"; \n" +
"  if (x > {1}) {0} ((x +{2}) / 2); \n" +
"}};"
si apelul List<ProblemType2> PType2 = GeneratorEngine.GenerateNProblems<ProblemType2>(4);
PType2.ForEach(p => Console.WriteLine(p.ProblemText));

Textele problemelor generate sunt: 
Subprogramul h este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de 4 ori.
void h (int x){
  cout << "*";
  if (x > 6) h ((x +2) / 2);
};
Subprogramul g este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de 5 ori.
void g (int x){
  cout << "*";
  if (x > 7) g ((x +2) / 2);
};
Subprogramul f este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de 5 ori.
void f (int x){
  cout << "*";
  if (x > 5) f ((x +1) / 2);
};
Subprogramul g este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de 4 ori.
void g (int x){
  cout << "*";
  if (x > 7) g ((x +2) / 2);
};
Subprogramul f este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de 5 ori.
void f (int x){
  cout << "*";
  if (x > 7) f ((x +3) / 2);
};
Daca se defineste un alt tip de problema se poate apela direct:
GeneratorEngine.GenerateNProblems<ProblemTypeN>(100);
