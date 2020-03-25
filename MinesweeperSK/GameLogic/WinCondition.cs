using System;
using MinesweeperSK.Visuals;

namespace MinesweeperSK.GameLogic
{
    public class WinCondition
    {
        public static bool CheckWinCondition(int numberOfTiles)
        {
            // You win when all tiles are not "unvisited" and "marks" are only on bombs
            int[] bombTiles = Matrix.RetrieveTileNumbers();

            for (int i = 0; i < numberOfTiles; i++)
            {
                string tileState = Gameboard.GetCurrentTileState(i);

                if (tileState == Tiles.UnvisitedTile()) { return false; }
                if (tileState == Tiles.MarkedTile() & CheckNotBombTile(bombTiles, i)) { return false; }
            }

            return true;

            bool CheckNotBombTile(int[] bombTilesArray, int index)
            {
                foreach (int tile in bombTilesArray)
                {
                    if (tile == index) { return false;  }
                }
                return true;
            }
        }
    }
}
