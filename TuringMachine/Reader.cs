using System;
using System.Collections.Generic;
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

                }
            }

            return functions
        }

        public string ReadWord()
        {

        }
    }
}
