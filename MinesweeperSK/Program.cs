using System;
using MinesweeperSK.Visuals;
using MinesweeperSK.GameLogic;
using System.Collections.Generic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        static bool isPlaying = true;

        public static void Main(string[] args)
        {
            Gameboard.InitializeBoardState();
            Matrix.PrintMatrix();
            Gameboard.PrintTheBoard();

            while (isPlaying == true)
            {
                string tileChoice = UserSelection.SelectTile();
                var squaresToModify = SquareCheck.SquareCheckHandler(tileChoice);

                foreach (var tile in squaresToModify)
                {
                    if (tile.Value == Tiles.BombTile()) { isPlaying = false; }
                }

                Gameboard.UpdateTheBoardState(squaresToModify);
                Gameboard.PrintTheBoard();

            }
            Console.WriteLine("GAME OVER");
        }

    }
}
