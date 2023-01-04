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
        public enum Direction
        {
            Left,
            Right,
            Stay
        }
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
        private List<char> Tape;
        private readonly char _emptySymbol = 'B';
        private Dictionary<MachineArgument,MachineMove> InstructionsTable;
        private int state = 0;
        private int position = 0;
        private List<int> AcceptingStates;

        public Machine(Reader reader) 
        {

        }

        private void MakeMove()
        {

        }

        public int Compute()
        {
            return -1;
        }
        private bool CheckIfAccepting() => AcceptingStates.Contains(state);

        

    }
}
