using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    using System;

    public class TicTacToe
    {
        private char[,] board;
        public char currentPlayer;

        public TicTacToe()
        {
            board = new char[3, 3];
            currentPlayer = 'X'; // Player X starts first
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' '; // Initialize each cell as empty
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int row = 0; row < 3; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
            {
                Console.WriteLine("Invalid move! Try again.");
                return false ;
            }

            board[row, col] = currentPlayer;
            bool lbExit = CheckForWinner();
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Switch player after each move
            if (lbExit == true)
                return true;
            return false ;
        }

        private bool CheckForWinner()
        {
            // Check rows, columns, and diagonals for a winning condition
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    Console.WriteLine($"{board[i, 0]} wins!");
                    return true;
                }

                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    Console.WriteLine($"{board[0, i]} wins!");
                    return true;
                }
            }

            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                Console.WriteLine($"{board[0, 0]} wins!");
                return true;
            }

            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                Console.WriteLine($"{board[0, 2]} wins!");
                return  true;
            }

            // Check for a tie
            bool tie = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        tie = false; // Not a tie if there's an empty cell
                        break;
                    }
                }
                if (!tie) break;
            }

            if (tie)
            {
                Console.WriteLine("It's a tie!");
                return true;
            }
            return true;
        }
    }

}
