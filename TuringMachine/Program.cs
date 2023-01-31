//
using TuringMachine;

string pathToWord = "..\\..\\..\\test\\testAddW.txt";
string pathToFunction = "..\\..\\..\\test\\testAddF.txt";


var reader = new Reader(pathToWord, pathToFunction);
var machine = new Machine(reader);

machine.Compute();
