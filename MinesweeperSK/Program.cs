using System;
using MinesweeperSK.Visuals;
using MinesweeperSK.GameLogic;
using MinesweeperSK.Text;
using System.Collections.Generic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        public static void Main()
        {
            StartingScreen.PrintStartingScreen();
            int selection = StartingScreen.ManageStartingScreen();
            
            bool isPlaying = true;

            Gameboard.InitializeBoardState(81);
            //Matrix.PrintMatrix();
            Gameboard.PrintTheBoard(true);

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
                    Gameboard.PrintTheBoard(false);
                }

                bool wonGame = WinCondition.CheckWinCondition(81);
                if (wonGame) { isPlaying = false; Console.WriteLine("YOU WIN!!!!"); }
            }
            GameOver.PrintGameOver();

            bool deciding = true;

            while (deciding)
            {
                Console.WriteLine("Would you like to play again? (y/n)");
                string response = Console.ReadLine();

                UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 2);

                if (response.ToLower() == "y")
                {
                    deciding = false;
                    GameOver.EraseGameOver();
                    Gameboard.EraseTheBoard();
                    Main();
                }
                if (response.ToLower() == "n") { return; }

            }
        }

    }
}
