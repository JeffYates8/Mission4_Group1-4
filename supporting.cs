namespace Mission4_Group1_4;

public class Supporting
{
    private char[,] board; // Jagged array

    public Supporting(char[,] inputArray) // Constructor
    {
        board = inputArray;
    }

    public void printBoard()
    {
        Console.WriteLine(" 1 | 2 | 3 \n ------------ \n  4 | 5 | 6 \n ------------  7 | 8 | 9");
    } 
    public bool updateBoard(int position, string player)
    {
        bool updated = false;

        int row = (position - 1) / 3;
        int col = (position - 1) % 3;

        board[row, col] = player;
        
    }
}