using System;
using MinesweeperSK.Visuals;
using MinesweeperSK.GameLogic;
using System.Collections.Generic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        public static void Main(string[] args)
        {
            bool isPlaying = true;

            Gameboard.InitializeBoardState();
            Matrix.PrintMatrix();
            Gameboard.PrintTheBoard();

            while (isPlaying == true)
            {
                
                string tileChoice = UserSelection.SelectTile();

                if (tileChoice != "marked")
                {
                    var squaresToModify = SquareCheck.SquareCheckHandler(tileChoice);

                    foreach (var tile in squaresToModify)
                    {
                        if (tile.Value == Tiles.BombTile()) { isPlaying = false; }
                    }

                    Gameboard.UpdateTheBoardState(squaresToModify);
                    Gameboard.PrintTheBoard();
                }

                bool wonGame = WinCondition.CheckWinCondition(81);
                if (wonGame) { isPlaying = false; Console.WriteLine("YOU WIN!!!!"); }
            }
            Console.WriteLine("GAME OVER");
            // TODO: show all bomb tiles
            // TODO: Print Text.GameOver (with time, stats, etc)
            Console.ReadLine();

            bool deciding = true;

            while (deciding)
            {
                Console.WriteLine("Would you like to play again? (y/n)");
                string response = Console.ReadLine();

                if (response.ToLower() == "y") { deciding = false;  Main(new string[0]); }
                if (response.ToLower() == "n") { return; }
            }
        }

    }
}
