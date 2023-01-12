//
using TuringMachine;

string pathToWord = "..\\..\\..\\testW.txt";
string pathToFunction = "..\\..\\..\\testF.txt";


var reader = new Reader(pathToWord, pathToFunction);
var machine = new Machine(reader);

machine.Compute();
