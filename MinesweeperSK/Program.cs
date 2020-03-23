using System;
using MinesweeperSK.Visuals;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        static bool isPlaying = true;

        public static void Main(string[] args)
        {
            Gameboard.InitializeBoardState();
            Gameboard.PrintTheBoard();
            
            while (isPlaying == true)
            {
                string tileChoice = UserSelection.SelectTile();
                //Console.WriteLine(string.Format("You chose tile {0}", tileChoice));
                // do some logic
                SquareCheck.ModifyTheTiles();
            }
        }

    }
}
