# Turing Machine

An implementation of the Turing Machine computational model.

## Overview

This project implements a Turing Machine simulator that can execute custom programs to demonstrate computational theory concepts and algorithm behavior.

## Features

- Infinite tape simulation
- State machine implementation
- Tape operations (read, write, move)
- Program definition and execution
- Step-by-step execution visualization
- Program validation
- Multiple machine configurations

## Installation

```bash
git clone https://github.com/jasiu648/TuringMachine.git
cd TuringMachine
```

## Building

```bash
dotnet build
```

## Running

```bash
dotnet run
```

## Usage

Define a Turing Machine program:

```csharp
var machine = new TuringMachine();
machine.LoadProgram("program.tm");
machine.Execute();
```

## Program Format

```
States: q0, q1, q2, qAccept, qReject
Alphabet: 0, 1, _
Tape: 0101
Initial: q0
Accept: qAccept

Transitions:
q0,0 -> q1,1,R
q1,1 -> q2,0,L
q2,_ -> qAccept,_,R
```

## Technology Stack

- C#
- .NET Framework / .NET Core
- Data structures (State, Transition, Tape)

## Project Structure

```
.
├── TuringMachine.cs   # Main machine class
├── State.cs           # State representation
├── Transition.cs      # Transition rules
├── Tape.cs            # Infinite tape
├── Parser.cs          # Program parser
├── Examples/
│   ├── add.tm
│   ├── multiply.tm
│   └── palindrome.tm
└── Tests/
```

## Examples

- Addition machine
- Multiplication machine
- Palindrome checker
- Binary incrementer

## Visualization

The application provides:
- Current state display
- Tape visualization
- Current position marker
- Step counter
- Execution history

## License

MIT License