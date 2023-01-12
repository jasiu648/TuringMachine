using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class Reader
    {
        private string pathToWord;
        private string pathToFunctions;

        public Reader(string pathToWord, string pathToFunction)
        {
            this.pathToWord = pathToWord;
            this.pathToFunctions = pathToFunction;
        }

        public Dictionary<MachineArgument, MachineMove> ReadFunctions()
        {
            var functions = new Dictionary<MachineArgument, MachineMove>();
            using (var reader = new StreamReader(pathToFunctions))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    var subs = line.Split(' ');
                    if (subs.Length != 5)
                        throw new Exception();

                    
                    var direction = GetDirection(subs[4]);
                    
                    var argument = new MachineArgument() { State = Int32.Parse(subs[0]), Symbol = Convert.ToChar(subs[1]) };               
                    var move = new MachineMove() { State = Int32.Parse(subs[2]), Symbol = Convert.ToChar(subs[3]), Direction = direction };

                    try
                    {
                        functions.Add(argument, move);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return functions;
        }

        private static MoveDirection GetDirection(string direction)
        {
            if(direction == "L")
                return MoveDirection.Left;

            if(direction == "R")
                return MoveDirection.Right;

            if (direction == "S")
                return MoveDirection.Stay;

            throw new ArgumentException();
        }

        public string ReadWord()
        {
            string line;
            using(var reader = new StreamReader(pathToWord))
            {
                line = reader.ReadLine();
            }

            return line;
        }
    }
}
