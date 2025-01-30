namespace Mission4_Group1_4;

class supporting
{
    public static void updateBoard(char[,] board)
    {
        // this prints the board game out for the player to see, it does so dynamically 
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
            // this if statement goes through the possible combinations of wins for across rows
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return $"Player {board[i, 0]} wins!";
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return $"Player {board[0, i]} wins!";
        }

        // Check diagonals
        // this if statement goes through the possible combinations of wins diaogonally 
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return $"Player {board[0, 0]} wins!";
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return $"Player {board[0, 2]} wins!";

        // No winner yet
        return null;
    }
}