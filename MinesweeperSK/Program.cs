using System;
using MinesweeperSK.Visuals;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        public static void Main(string[] args)
        {
            Gameboard.InitializeBoardState();
            Gameboard.PrintTheBoard();
        }
    }
}
