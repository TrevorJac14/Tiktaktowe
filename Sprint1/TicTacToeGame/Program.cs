using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; // 1 for Player 1, 2 for Player 2

    static void Main()
    {
        bool gameActive = true;
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");

            // Draw the tic-tac-toe board
            DrawBoard();

            // Check for a win or a draw
            if (currentPlayer % 2 == 0)
            {
                Console.WriteLine("Player 2's turn (O)");
            }
            else
            {
                Console.WriteLine("Player 1's turn (X)");
            }

            // Get the player's choice and validate it
            choice = GetChoice();

            // Update the board with the player's move
            if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
            {
                board[choice - 1] = (currentPlayer % 2 == 0) ? 'O' : 'X';
                currentPlayer++;
            }

            // Check for a win or a draw
            gameActive = !CheckForWin() && !CheckForDraw();

        } while (gameActive);

        Console.Clear();
        DrawBoard();

        // Display the result of the game
        if (CheckForWin())
        {
            int winner = (currentPlayer - 1) % 2 + 1;
            Console.WriteLine($"Player {winner} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }

        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static int GetChoice()
    {
        int choice;
        bool validInput;

        do
        {
            Console.Write("Enter a number (1-9): ");
            validInput = int.TryParse(Console.ReadLine(), out choice);

            if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
            {
                Console.WriteLine("Invalid input. Try again.");
                validInput = false;
            }
        } while (!validInput);

        return choice;
    }

    static bool CheckForWin()
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 8; i++)
        {
            string line = "";
            switch (i)
            {
                case 0:
                    line = $"{board[0]}{board[1]}{board[2]}";
                    break;
                case 1:
                    line = $"{board[3]}{board[4]}{board[5]}";
                    break;
                case 2:
                    line = $"{board[6]}{board[7]}{board[8]}";
                    break;
                case 3:
                    line = $"{board[0]}{board[3]}{board[6]}";
                    break;
                case 4:
                    line = $"{board[1]}{board[4]}{board[7]}";
                    break;
                case 5:
                    line = $"{board[2]}{board[5]}{board[8]}";
                    break;
                case 6:
                    line = $"{board[0]}{board[4]}{board[8]}";
                    break;
                case 7:
                    line = $"{board[2]}{board[4]}{board[6]}";
                    break;
            }
            if (line == "XXX" || line == "OOO")
                return true;
        }
        return false;
    }

    static bool CheckForDraw()
    {
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false; // The game is not a draw
            }
        }
        return true; // All cells are filled; it's a draw
    }

}
