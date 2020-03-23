using System;

namespace MinesweeperSK.GameLogic
{
    public class Matrix
    {
        private static int[] gameMatrix = new int[81];
        private static int[] bombTiles = new int[12];

        public static void GenerateMatrix()
        {
            int numberOfMines = 12;
            var rand = new Random();

            for (int i = 0; i < numberOfMines; i++)
            {
                int temp = rand.Next(81);

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
                Console.WriteLine(gameMatrix[i]);
            }
        }

        public static int[] RetrieveTileNumbers()
        {
            return bombTiles;
        }

    }
}
