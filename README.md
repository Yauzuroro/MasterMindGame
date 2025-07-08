# MasterMindGame
this project for savvy and education purposes Only.

This is a simple console-based version of the classic Mastermind game, developed in C# using object-oriented programming principles.

## About the Game

Mastermind is a code-breaking game where the player has to guess a secret 4-digit code. Each digit is unique and selected from numbers 0 to 8.

After each guess, the game provides feedback:
- **Well-placed pieces**: digits that are correct and in the correct position.
- **Misplaced pieces**: digits that exist in the code but are in the wrong position.

The player has a limited number of attempts to guess the code correctly. If the player succeeds, they win. If not, the game ends. After finishing, the player has the option to play again.

## Features

- Written in C# using clean object-oriented programming (classes, methods, encapsulation)
- Command-line argument support:
  - `-c [CODE]`: specify a custom secret code
  - `-t [ATTEMPTS]`: set a custom number of attempts (default is 10)
- Input validation for guesses
- Clean handling of EOF input (Ctrl + D)
- Option to restart the game after completion

## How to Run

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your system

### Steps

1. Open your terminal and navigate to the folder where you want to create the project.
2. Run the following commands:

```bash
dotnet new console -n MastermindGame
cd MastermindGame
