using System;
using MinesweeperSK.GameLogic;
using MinesweeperSK.Text;
using System.Collections.Generic;

namespace MinesweeperSK
{
    
    class GameFlow
    {
        public static DateTime startTime = DateTime.Now;

        public static void Main()
        {
            startTime = DateTime.Now;
            StartingScreen.PrintStartingScreen();

            string boardSizeSelection = StartingScreen.ManageStartingScreen();
            
            bool isPlaying = true;
            bool winner = false;

            BoardState.InitializeBoardState(boardSizeSelection);
            //Matrix.PrintMatrix();

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

                    BoardState.UpdateTheBoardState(squaresToModify);
                }

                bool wonGame = WinCondition.CheckWinCondition(BoardState.gameboardSize);
                if (wonGame)
                {
                    winner = true;
                    isPlaying = false; Console.WriteLine("YOU WIN!!!!");
                }
            }
            GameOver.PrintGameOver();

            bool deciding = true;

            while (deciding)
            {
                Console.WriteLine("Would you like to play again? (y/n)");
                string response = Console.ReadLine();

                if (winner) { UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 3); }
                else { UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 2); }

                if (response.ToLower() == "y")
                {
                    deciding = false;
                    GameOver.EraseGameOver();
                    BoardState.EraseTheBoard();
                    Main();
                }
                if (response.ToLower() == "n") { return; }

            }
        }

    }
}
