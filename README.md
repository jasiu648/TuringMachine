# Turing Machine

A C# implementation of a Turing Machine simulator for computational theory and algorithm demonstration.

## Overview

This project implements a functional Turing Machine that reads transition rules from files and executes computations on an infinite tape. The machine simulates the fundamental model of computation used in theoretical computer science.

## Core Components

### Machine.cs
- **Machine** class: Core simulator that processes input symbols according to transition rules
  - Manages tape as a dynamic list that expands infinitely in both directions
  - Tracks current state, tape position, and move count
  - Detects infinite loops using tape history
  - Outputs step-by-step execution visualization

### Reader.cs
- **Reader** class: File-based input handler for transition functions and input word
  - Reads transition rules from a file
  - Reads the input word from a separate file
  - Parses direction commands (L=Left, R=Right, S=Stay)

### Data Structures
- **MachineArgument**: Input tuple (State, Symbol) - represents current configuration
- **MachineMove**: Output action (NextState, SymbolToWrite, Direction)
- **MoveDirection**: Enum for tape head movement (Left, Right, Stay)

## Features

- **Infinite Tape Simulation**: Dynamic tape that expands on demand with blank symbols ('0')
- **State-Based Computation**: Configurable initial state (default: 1) and accepting state (default: 0)
- **Infinite Loop Detection**: Tracks tape history to detect and terminate infinite computations
- **Execution Limits**: Max 10,000 moves per computation
- **Step-by-Step Visualization**: Console output showing:
  - Current state and symbol at each step
  - Next state and symbol to write
  - Movement direction
  - Complete tape representation with head position indicator
  - Move counter
- **Error Handling**: Catches undefined transitions and invalid configurations

## File Format

### Transition Rules File
Each line contains a transition rule (space-separated):
```
CurrentState CurrentSymbol NextState SymbolToWrite Direction
```

Example:
```
1 0 2 1 R
1 1 1 0 L
2 0 2 1 R
2 1 0 0 S
0 0 0 0 S
```

Where:
- `Direction` can be: `L` (Left), `R` (Right), `S` (Stay)

### Input Word File
Single line containing the input string:
```
0101110
```

## Usage

```csharp
var reader = new Reader("path/to/input.txt", "path/to/rules.txt");
var machine = new Machine(reader);
machine.Compute();
```

The program will:
1. Load the input word onto the tape
2. Start in state 1 at position 0
3. Execute transitions according to the rules
4. Print each step's execution details
5. Terminate when reaching state 0 (accepting state)
6. Report if an infinite loop is detected

## Output Example

```
Stan maszyny po 0 ruchach: 
0 1 0 1 
^

Obecny stan 1, obecny symbol 0. Maszyna napisze symbol 1, wejdzie w stan 2 i wykona ruch Right 

Stan maszyny po 1 ruchach: 
1 1 0 1 
  ^

[... more steps ...]

Maszyna zakonczyla obliczenia. Wynik: 
[final tape content]
```

## Technical Details

- **Language**: C# (.NET Framework / .NET Core)
- **Tape Representation**: `List<char>`
- **Transition Table**: `Dictionary<MachineArgument, MachineMove>`
- **Cycle Detection**: `HashSet<(int state, int position, string tapeContent)>`
- **Default Blank Symbol**: '0'
- **Default Accepting State**: 0
- **Default Initial State**: 1

## Limitations

- Maximum 10,000 moves before timeout
- Single-character input alphabet
- No multi-tape support
- No lookahead or backtracking

## License

MIT License
