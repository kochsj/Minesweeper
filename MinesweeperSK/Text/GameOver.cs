using System;
using System.Collections.Generic;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK.Text
{
    public class GameOver
    {
        public static void PrintGameOver()
        {
            ShowAllBombTiles();

            Console.WriteLine("GAME OVER");

            PrintGameStats();

            Console.ReadLine();
        }

        public static void EraseGameOver()
        {
            UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 3);
        }

        public static void ShowAllBombTiles()
        {
            int[] bombTiles = Matrix.RetrieveTileNumbers();
            Dictionary<int, string> tileDict = new Dictionary<int, string>();

            foreach (int bombTile in bombTiles)
            {
                tileDict.Add(bombTile, Tiles.BombTile());
            }

            BoardState.UpdateTheBoardState(tileDict);
        }

        public static void PrintGameStats()
        {
            var elapsedTime = DateTime.Now.Subtract(GameFlow.startTime);
            Console.WriteLine("Time elapsed: {0:mm\\:ss}", elapsedTime);
        }
    }
}
