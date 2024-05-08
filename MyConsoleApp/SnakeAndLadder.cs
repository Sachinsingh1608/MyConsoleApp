using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public class SnakeAndLadder
    {
        private int[] _Iobjboard;
     
        private int[] _IobjplayerPos;
        

        public SnakeAndLadder()
        {
            _Iobjboard = new int[100];
            _IobjplayerPos = new int[2];

            CreateSnakeAndLaddeBoardStructure();
        }
        private void  CreateSnakeAndLaddeBoardStructure()
        {
            // create Board;
            for(int lnCnt = 0; lnCnt < _Iobjboard.Length; lnCnt++)
            {
                _Iobjboard[lnCnt] = lnCnt + 1;
            }


            // Snake Create

            _Iobjboard[62] = 19;
            _Iobjboard[64] = 60 ;
            _Iobjboard[54] = 34;
            _Iobjboard[87] = 36;
            _Iobjboard[93] = 73;
            _Iobjboard[95] = 75;
            _Iobjboard[96] = 79;


            //ladder
            _Iobjboard[4] = 14;
            _Iobjboard[9] = 31;
            _Iobjboard[2] = 38;
            _Iobjboard[21] = 42;
            _Iobjboard[51] = 67;
            _Iobjboard[28] = 84;
            _Iobjboard[80] = 99;
            _Iobjboard[72] = 91;


        }
        public void PlayGame()
        {
            int currentPlayer = 0;
            while (true)
            {
                Console.WriteLine("Current Player :- " + (currentPlayer + 1)+ "   And Previous Pos :-  "+
                    _IobjplayerPos[currentPlayer]);
                PlayTurn(currentPlayer);
               
                Console.ReadKey();
                if (_IobjplayerPos[currentPlayer] == 100)
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
           
            Random lnrandom = new Random();
            int diceValue = lnrandom.Next(1, 7);


            _IobjplayerPos[player] += diceValue;

 
            if (_IobjplayerPos[player] < _Iobjboard.Length)
            {
                _IobjplayerPos[player] = _Iobjboard[_IobjplayerPos[player] - 1];
            }

            Console.WriteLine($"Player {player + 1} rolled {diceValue}, moved to position {_IobjplayerPos[player]}");
        }
    }



}

