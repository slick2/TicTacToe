using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        int move;
        bool gameWon = false;

        while (!gameWon && !BoardFull())
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
            move = int.Parse(Console.ReadLine());

            if (board[move - 1] != 'X' && board[move - 1] != 'O')
            {
                board[move - 1] = currentPlayer;
                gameWon = CheckWin();
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
                Console.ReadKey();
            }
        }

        Console.Clear();
        PrintBoard();
        if (gameWon)
        {
            Console.WriteLine($"Player {(currentPlayer == 'X' ? 'O' : 'X')} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }

    static bool CheckWin()
    {
        int[,] winPositions = {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
            {0, 4, 8}, {2, 4, 6}             // Diagonals
        };

        for (int i = 0; i < winPositions.GetLength(0); i++)
        {
            if (board[winPositions[i, 0]] == board[winPositions[i, 1]] &&
            board[winPositions[i, 1]] == board[winPositions[i, 2]])
            {
                return true;
            }
        }

        return false;
    }

    static bool BoardFull()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
