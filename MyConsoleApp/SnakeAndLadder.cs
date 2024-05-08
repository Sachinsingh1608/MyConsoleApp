using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public class SnakeAndLadder
    {
        private int[] board;
        private int WinPos;
        private int[] playerPos;
        

        public SnakeAndLadder()
        {
            board = new int[100];
            playerPos = new int[2];
            WinPos = 100;
            CreateSnakeAndLaddeBoard();
        }
        private void  CreateSnakeAndLaddeBoard()
        {
            // create Board;
            for(int lnCnt = 0; lnCnt < board.Length; lnCnt++)
            {
                board[lnCnt] = lnCnt + 1;
            }


            // Snake Create

            board[17] = 7;
            board[62] = 19;
            board[64] = 60 ;
            board[54] = 34;
            board[87] = 36;
            board[93] = 73;
            board[95] = 75;
            board[96] = 79;


            //ladder
            board[4] = 14;
            board[9] = 31;
            board[2] = 38;
            board[21] = 42;
            board[51] = 67;
            board[28] = 84;
            board[80] = 99;
            board[72] = 91;


        }
        public void PlayGame()
        {
            int currentPlayer = 0;
            while (true)
            {
                Console.WriteLine("Current Player :- " + (currentPlayer + 1)+ "   And Previous Pos :-  "+
                    playerPos[currentPlayer]);
                PlayTurn(currentPlayer);
               
                Console.ReadKey();
                if (playerPos[currentPlayer] == WinPos)
                {
                    Console.WriteLine($"Player {currentPlayer + 1} wins!");
                    break;
                }
                currentPlayer = (currentPlayer + 1) % 2;
                Console.Clear();

            }
        }
        private void PlayTurn(int player)
        {
           
            Random random = new Random();
            int diceValue = random.Next(1, 7);

            
            playerPos[player] += diceValue;

 
            if (playerPos[player] < board.Length)
            {
                playerPos[player] = board[playerPos[player] - 1];
            }

            Console.WriteLine($"Player {player + 1} rolled {diceValue}, moved to position {playerPos[player]}");
        }
    }



}

