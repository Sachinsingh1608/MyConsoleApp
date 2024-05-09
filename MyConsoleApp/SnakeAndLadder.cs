using System;
using System.Collections.Generic;


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
            HashSet<int> IobjSet = new HashSet<int>();
            Random IobjRandom  = new Random();
            for(int lncnt =0; lncnt<8; )
            {
                int lnst = IobjRandom.Next(1, 101);
                int lnend = IobjRandom.Next(1, lnst);
                if(!IobjSet.Contains(lnst) && !IobjSet.Contains(lnend))
                {
                    _Iobjboard[lnst]=lnend;
                    IobjSet.Add(lnst);
                    IobjSet.Add(lnend);
                    lncnt++;
                    Console.WriteLine(_Iobjboard[lnst]);

                }
            }
            //ladder
            Console.WriteLine("Ladder");
            for (int lncnt = 0; lncnt < 8; )
            {
                int lnst = IobjRandom.Next(1, 100);
                int lnend = IobjRandom.Next(lnst+1, 100);
                if (!IobjSet.Contains(lnst) && !IobjSet.Contains(lnend))
                {
                    _Iobjboard[lnst] = lnend;
                    IobjSet.Add(lnst);
                    IobjSet.Add(lnend);
                    lncnt++;
                   Console.WriteLine(_Iobjboard[lnst]);


                }
           
            }
          


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

