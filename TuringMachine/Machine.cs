using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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
        private readonly char _emptySymbol = '0';
        private readonly int _acceptingState = 0;
        private readonly int _maxMovesCount = 10000;
        private Dictionary<MachineArgument,MachineMove> InstructionsTable;

        private List<char> Tape;
        private int state = 1;
        private int position = 0;
        private int movesCount = 0;

        public Machine(Reader reader) 
        {
            InstructionsTable = reader.ReadFunctions();
            var word = reader.ReadWord();
            Tape = new List<char>();
            LoadWord(word);
        }
        private void LoadWord(string word)
        {
            char[] chars = word.ToCharArray();
            Tape.AddRange(chars);
        }
        
        private void UpdatePosition(MoveDirection direction)
        {
            if(direction == MoveDirection.Right)
            {
                position++;
                if(position >= Tape.Count)
                {
                    Tape.Add(_emptySymbol);
                }
            }
            else if (direction == MoveDirection.Left)
            {
                if(position == 0)
                {
                    Tape.Insert(0,_emptySymbol);
                }
            }
        }
        private void MakeMove()
        {
            var argument = new MachineArgument() { State = state, Symbol = GetCurrentSymbol()};

            if (!InstructionsTable.TryGetValue(argument, out MachineMove move))
                throw new InvalidOperationException();

            PrintMove(argument,move);
            Tape[position] = move.Symbol;
            state = move.State;
            UpdatePosition(move.Direction);
            movesCount++;
        }

        private void PrintMove(MachineArgument argument, MachineMove move)
        {
            Console.WriteLine($"Obecny stan {argument.State}, obecny symbol {argument.Symbol}." +
                $" Maszyna napisze symbol {move.Symbol}, wejdzie w stan {move.State} i wykona ruch {move.Direction}");
        }

        public void Compute()
        {
            PrintTape();

            while (!CheckIfAccepting())
            {
                MakeMove();
                PrintTape();
            }

            PrintResult();
        }

        private void PrintTape()
        {
            Console.Write($"Stan maszyny po {movesCount} ruchach: \n");
            foreach(var symbol in Tape)
            {
                Console.Write(symbol.ToString() + " ");
            }
            Console.WriteLine();

            StringBuilder positionIndicator = new StringBuilder();
            positionIndicator.Append(' ', 2 * position);
            positionIndicator.Append('^');

            Console.WriteLine(positionIndicator.ToString());
            Console.WriteLine();
            
        }

        private void PrintResult()
        {
            Console.Write($"Maszyna zakonczyla obliczenia. Wynik: \n");
            foreach (var symbol in Tape)
            {
                Console.Write(symbol.ToString() + " ");
            }
            Console.WriteLine();
        }
        private bool CheckIfAccepting() => state == _acceptingState;

        private char GetCurrentSymbol() => Tape[position];
        

    }
}
