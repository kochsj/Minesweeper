using System;
using System.Collections.Generic;
using MinesweeperSK.Visuals;

namespace MinesweeperSK.GameLogic
{
    public class BoardState
    {
        private static string[] boardState;

        public static int gameboardSize;

        public static string gameDifficulty;

        public enum BoardSizes
        {
            easy=25,
            regular=81,
            hard=256,

        }


        public static void InitializeBoardState(string difficulty)
        {
            gameDifficulty = difficulty;

            if (gameDifficulty == "easy") { gameboardSize = (int)BoardSizes.easy; }
            if (gameDifficulty == "regular") { gameboardSize = (int)BoardSizes.regular; }
            if (gameDifficulty == "hard") { gameboardSize = (int)BoardSizes.hard; }

            boardState = new string[gameboardSize];

            Matrix.GenerateMatrix(gameboardSize);

            for (int i = 0; i < boardState.Length; i++)
            {
                boardState[i] = Tiles.UnvisitedTile();
            }

            PrintTheBoard(true);
        }


        public static string GetCurrentTileState(int tileID)
        {
            return boardState[tileID];
        }


        public static void UpdateTheBoardState(Dictionary<int, string> tileDict)
        {
            foreach (KeyValuePair<int, string> tileToChange in tileDict)
            {
                //Console.WriteLine(string.Format("changing tile: {0}, with: {1}", tileToChange.Key, tileToChange.Value));
                if (tileToChange.Key <= 80)
                {
                    boardState[tileToChange.Key] = tileToChange.Value;
                    //Console.WriteLine(string.Format("officially changed tile: {0}", tileToChange.Key));
                }
            }

            PrintTheBoard(false);
        }


        public static void PrintTheBoard(bool firstRound)
        {
            //Console.Clear();
            if (firstRound)
            {
                UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 4);
            }
            else
            {
                EraseTheBoard();
            }

            string theBoard = GameboardVisuals.GameboardHandler(gameDifficulty, boardState);

            Console.WriteLine(theBoard);
        }

        public static void EraseTheBoard()
        {
            int tilesToErase = 0;

            if (gameDifficulty == "easy") { tilesToErase = 12; }
            if (gameDifficulty == "regular") { tilesToErase = 20; }
            if (gameDifficulty == "hard") { tilesToErase = 34; }

            UserSelection.ClearCurrentConsoleLine(Console.CursorTop, tilesToErase);
        }

        public static void PrintTheBoardDepracated()
        {
            Console.WriteLine(@"    a   b   c   d   e   f   g   h   i  ");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"1 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"2 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"3 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"4 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"5 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"6 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"7 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"8 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"9 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
        }
    }
}
