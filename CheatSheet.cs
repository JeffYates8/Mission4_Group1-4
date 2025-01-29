using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        char currentPlayer = 'X';
        int moves = 0;
        bool gameOver = false;

        while (!gameOver)
        {
            Supporting.updateBoard(board);
            Console.WriteLine($"Player {currentPlayer}, choose a position (1-9): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int position) || position < 1 || position > 9)
            {
                Console.WriteLine("Invalid input. Please choose a number between 1 and 9.");
                continue;
            }

            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board[row, col] == 'X' || board[row, col] == 'O')
            {
                Console.WriteLine("Spot already taken. Choose another.");
                continue;
            }

            board[row, col] = currentPlayer;
            moves++;

            string winner = Supporting.getWinner(board);
            if (winner != null)
            {
                Supporting.updateBoard(board);
                Console.WriteLine(winner);
                gameOver = true;
            }
            else if (moves == 9)
            {
                Supporting.updateBoard(board);
                Console.WriteLine("It's a tie (Cat's game)!");
                gameOver = true;
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}

class Supporting
{
    public static void updateBoard(char[,] board)
    {
        Console.Clear();
        Console.WriteLine("Tic-Tac-Toe Board:");
        Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
    }

    public static string getWinner(char[,] board)
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return $"Player {board[i, 0]} wins!";
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return $"Player {board[0, i]} wins!";
        }

        // Check diagonals
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return $"Player {board[0, 0]} wins!";
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return $"Player {board[0, 2]} wins!";

        return null; // No winner yet
    }
}


