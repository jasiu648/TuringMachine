using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public struct MachineMove
    {
        public int State;
        public char Symbol;
        public MoveDirection Direction;
    }

    public enum MoveDirection
    {
        Left,
        Right,
        Stay
    }

    public struct MachineArgument 
    { 
        public int State;
        public char Symbol;

        public bool Equals(MachineArgument machineArgument) 
        {
            if(this.State == machineArgument.State && this.Symbol == machineArgument.Symbol)
                return true;
            return false;
        }
    }

    public class Machine
    {
        
        private readonly char _emptySymbol = 'B';
        private readonly int _acceptingState = 0;
        private Dictionary<MachineArgument,MachineMove> InstructionsTable;

        private List<char> Tape;
        private int state = 1;
        private int position = 0;
        

        public Machine(Reader reader) 
        {
            InstructionsTable = reader.ReadFunctions();
            var word = reader.ReadWord();
            LoadWord(word);
        }
        private void LoadWord(string word)
        {
            char[] chars = word.ToCharArray();
            Tape.AddRange(chars);
        }
        
        private void UpdatePosition(MoveDirection direction)
        {
            if(direction == MoveDirection.Left)
            {
                position++;
                if(position >= Tape.Count)
                {
                    Tape.Add(_emptySymbol);
                }
            }
            else if (direction == MoveDirection.Right)
            {
                position--;
                if(position < 0)
                {
                    throw new Exception();
                }
            }
        }
        private void MakeMove()
        {
            var argument = new MachineArgument() { State = state, Symbol = GetCurrentSymbol()};

            if (!InstructionsTable.TryGetValue(argument, out MachineMove move))
                throw new InvalidOperationException();

            Tape[position] = move.Symbol;
            state = move.State;
            UpdatePosition(move.Direction);
        }

        public void Compute()
        {
            while(state != 0)
            {
                PrintTape();
                MakeMove();
            }

            
        }

        private void PrintTape()
        {
            foreach(var symbol in Tape)
            {
                Console.Write(symbol.ToString() + " ");
            }
        }
        private bool CheckIfAccepting() => state == _acceptingState;

        private char GetCurrentSymbol() => Tape[position];
        

    }
}
