using Mission4_Group1_4;
class Program
{
    static void Main()
    {
        supporting s = new supporting();
        //welcomes the user to the game
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        //created a 2-D array with a nested array to create the game board
        char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        // initializes the variables
        // assigns a symbol (X) to the currentPlayer as their game piece
        char currentPlayer = 'X';
        // resets game so that the currnetPlayer is at 0 moves
        int moves = 0;
        // sets the game to false indicating that the game is not over yet
        bool gameOver = false;
        // a while loop to verify if the game is over yet, so if the game is equal to false,
        // then continue looping though the turns of the player
        while (!gameOver)
        {
            // uses the updateBoard method and passes in the board array to see
            // the updated board based on the player's moves
            supporting.updateBoard(board);
            // prompts the player to pick a spot on the board to place their symbol
            Console.WriteLine($"Player {currentPlayer}, choose a position (1-9): ");
            // reads the players input for which position number
            string input = Console.ReadLine();
            // if the desired position inputed by the currentPlayer is not an integer and it is not
            // within the bounds of 1-9, then tell them to enter another position between 1-9
            if (!int.TryParse(input, out int position) || position < 1 || position > 9)
            {
                Console.WriteLine("Invalid input. Please choose a number between 1 and 9. Hit enter to continue.");
                Console.ReadLine();
                continue;

            }
            // set row and column using uesr input, resulting values are automatically rounded
            // these equations will pinpoint the correct and desired position on the gameBoard
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;
            // checks the boardGame position to see if the spot that the currentPlayer
            // wants to place their symbol, is not yet taken
            if (board[row, col] == 'X' || board[row, col] == 'O')
            {
                // if the spot is taken, this prompts the user to choose another spot
                Console.WriteLine("Spot already taken. Choose another.Hit enter to continue.");
                Console.ReadLine();
                continue;
            }
            // the boardGame position is replaced by the current player's symbol
            board[row, col] = currentPlayer;
            // this increments the current player's number of moves
            moves++;
            // sets the winner to the result of the getWinner method
            string winner = supporting.getWinner(board);
            // if none of the possible ways to win are completed in the getWinner method, then null will be returned
            // if null is not returned and a winner is decided, then update the board
            // and set the gameOver to true which will signal that the game is over
            if (winner != null)
            {
                supporting.updateBoard(board);
                Console.WriteLine(winner);
                gameOver = true;
            }
            // is there have been 9 moves (all spots have been taken) and no one has won, then update the board and let the player know that the
            else if (moves == 9)
            {
                // this method updates the board game
                supporting.updateBoard(board);
                Console.WriteLine("It's a tie (Cat's game)!");
                // this changes the gameOver to actually be over
                gameOver = true;
            }
            else
            {
                // this changes the player to current player to be the player that hasn't gone yet
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}