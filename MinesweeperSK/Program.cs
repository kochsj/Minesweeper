using System;
using MinesweeperSK.Visuals;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        public static void Main(string[] args)
        {
            Gameboard.InitializeBoardState();
            Gameboard.PrintTheBoard();
            UserSelection.SelectTile();
        }

        
    }
}
