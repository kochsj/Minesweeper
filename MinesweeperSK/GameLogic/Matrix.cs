using System;

namespace MinesweeperSK.GameLogic
{
    public class Matrix
    {
        private static int[] gameMatrix = new int[81];
        private static int[] bombTiles;

        public static void GenerateMatrix(int boardSize)
        {
            double numberOfMines = boardSize * 0.15;

            bombTiles = new int[(int)numberOfMines];

            var rand = new Random();

            for (int i = 0; i < (int)numberOfMines; i++)
            {
                int temp = rand.Next(boardSize);

                while (gameMatrix[temp] != 0)
                {
                    temp = rand.Next(81);
                }

                gameMatrix[temp] = 1;
                bombTiles[i] = temp;
            }
        }

        public static void PrintMatrix()
        {
            for (int i = 0; i < gameMatrix.Length; i++)
            {
                Console.WriteLine(string.Format("Tile {0}: {1}", i, gameMatrix[i]));
            }
        }

        public static int[] RetrieveTileNumbers()
        {
            return bombTiles;
        }

    }
}
