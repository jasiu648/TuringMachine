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
            
        }

        private void MakeMove()
        {
            var argument = new MachineArgument() { State = state, Symbol = GetCurrentSymbol()};

            if (!InstructionsTable.TryGetValue(argument, out MachineMove move))
                throw new InvalidOperationException();

            


        }

        public int Compute()
        {
            return -1;
        }
        private bool CheckIfAccepting() => state == _acceptingState;

        private char GetCurrentSymbol() => Tape[position];
        

    }
}
