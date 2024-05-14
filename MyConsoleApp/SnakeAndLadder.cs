using System;
using System.Collections.Generic;


namespace MyConsoleApp
{
    public class SnakeAndLadder
    {
        private int[] _mnIobjboard;

        private int[] _mnIobjplayerPos;
        private string[] _msIobjPlayerName;


        public SnakeAndLadder(int inNumberOfplayer)
        {
            _mnIobjboard = new int[100];
            _mnIobjplayerPos = new int[inNumberOfplayer];
            _msIobjPlayerName = new string[inNumberOfplayer];
            
            Console.Clear();
            CreateSnakeAndLaddeBoardStructure();
            PlayGame();
        }
        private void PlayerNames(string[] _msIobjPlayerName)
        {
            Console.WriteLine("___________________Snake And Ladder_______________\n");
            for(int lncnt=0; lncnt< _msIobjPlayerName.Length; lncnt++)
            {
                Console.WriteLine("Enter player " +(lncnt+1)+" Name");
                string lsName = Console.ReadLine();
                _msIobjPlayerName[lncnt] = lsName;
            }
        }
        private void CreateSnakeAndLaddeBoardStructure()
        {
            // create Board;
            for (int lnCnt = 0; lnCnt < _mnIobjboard.Length; lnCnt++)
            {
                _mnIobjboard[lnCnt] = lnCnt + 1;
            }
            // Snake Create
            List<int> IobjSet = new List<int>();
            Random IobjRandom  = new Random();
            for(int lncnt =0; lncnt<8; )
            {
                int lnst = IobjRandom.Next(1, 100);
                int lnend = IobjRandom.Next(1, lnst);
                if(!IobjSet.Contains(lnst) && !IobjSet.Contains(lnend))
                {
                    _mnIobjboard[lnst]=lnend;
                    IobjSet.Add(lnst);
                    IobjSet.Add(lnend);
                    lncnt++;
                }
            }
            //ladder
           
            for (int lncnt = 0; lncnt < 8; )
            {
                int lnst = IobjRandom.Next(1, 100);
                int lnend = IobjRandom.Next(lnst+1, 100);
                if (!IobjSet.Contains(lnst) && !IobjSet.Contains(lnend))
                {
                    _mnIobjboard[lnst] = lnend;
                    IobjSet.Add(lnst);
                    IobjSet.Add(lnend);
                    lncnt++;
                }
            }
        }
        private void PlayGame()
        {
            int lncurrentPlayer = 0;
            Console.WriteLine("Enter 1 For  Start Game");
            int lnSt = int.Parse(Console.ReadLine());
            PlayerNames(_msIobjPlayerName);
            bool lnGameWin = true;
            while (lnGameWin && lnSt != 0)
            {
                Console.WriteLine("Current Player :- " + (lncurrentPlayer + 1) + "   And Previous Pos :-  " +
                    _mnIobjplayerPos[lncurrentPlayer]);
                PlayTurn(lncurrentPlayer);
                if (_mnIobjplayerPos[lncurrentPlayer] == 100)
                {
                    Console.WriteLine($"Player {_msIobjPlayerName[lncurrentPlayer]} wins!");
                    break;
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                   break;
                }
                lncurrentPlayer = (lncurrentPlayer + 1) % _msIobjPlayerName.Length;
                Console.Clear();
            }
        }
        private void PlayTurn(int inplayer)
        {
            Random random = new Random();
            int diceValue = random.Next(1, 7);

            if (_mnIobjplayerPos[inplayer] == 0 && diceValue != 1)
            {
                Console.WriteLine($"Player {_msIobjPlayerName[inplayer]} Rolled {diceValue}, But need a 1 to Start a Game");
                return;
            }
            int lnnewPosition = _mnIobjplayerPos[inplayer] + diceValue;

            if (lnnewPosition <= _mnIobjboard.Length)
            {
                _mnIobjplayerPos[inplayer] = _mnIobjboard[lnnewPosition - 1];
            }
            Console.WriteLine($"Player {_msIobjPlayerName[inplayer]}  rolled {diceValue}, moved to position {_mnIobjplayerPos[inplayer]}");
        }
    }
}

