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