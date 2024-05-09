using System;


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
        private void CreateSnakeAndLaddeBoardStructure()
        {
            // create Board;
            for (int lnCnt = 0; lnCnt < _Iobjboard.Length; lnCnt++)
            {
                _Iobjboard[lnCnt] = lnCnt + 1;
            }


            // Snake Create

            _Iobjboard[62] = 19;
            _Iobjboard[64] = 60;
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
            _Iobjboard[81] = 99;
            _Iobjboard[72] = 91;


        }
        public void PlayGame()
        {
            int lncurrentPlayer = 0;
            Console.WriteLine("Enter 1 For  Start Game");
            int lnSt = int.Parse(Console.ReadLine());
            bool lnGameWin = true;
            while (lnGameWin && lnSt != 0)
            {
                Console.WriteLine("Current Player :- " + (lncurrentPlayer + 1) + "   And Previous Pos :-  " +
                    _IobjplayerPos[lncurrentPlayer]);
                PlayTurn(lncurrentPlayer);




                if (_IobjplayerPos[lncurrentPlayer] == 100)
                {
                    Console.WriteLine($"Player {lncurrentPlayer + 1} wins!");
                    break;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
               
               
            
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    if (lncurrentPlayer == 0)
                        Console.WriteLine("Win Player  :-   " + (lncurrentPlayer + 2)+"     Player  "+(lncurrentPlayer+1)+" exit");
                    else
                        Console.WriteLine("Win Player :-  " + (lncurrentPlayer) + "     Player  " + (lncurrentPlayer+1) + " exit");

                    break;
                }
                lncurrentPlayer = (lncurrentPlayer + 1) % 2;
                Console.Clear();

            }
        }
        private void PlayTurn(int inplayer)
        {
            Random random = new Random();
            int diceValue = random.Next(1, 7);

            if (_IobjplayerPos[inplayer] == 0 && diceValue != 1)
            {
                Console.WriteLine($"Player {inplayer + 1} Rolled {diceValue}, But need a 1 to Start a Game");
                return;
            }
            int lnnewPosition = _IobjplayerPos[inplayer] + diceValue;

            if (lnnewPosition <= _Iobjboard.Length)
            {
                _IobjplayerPos[inplayer] = _Iobjboard[lnnewPosition - 1];
            }

            Console.WriteLine($"Player {inplayer + 1} rolled {diceValue}, moved to position {_IobjplayerPos[inplayer]}");
        }

    }



}

