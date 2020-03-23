using System;
namespace MinesweeperSK.Visuals
{
    public class Tiles
    {
        public static string UnvisitedTile()
        {
            string ut = @" * |";
            return ut;
        }

        public static string EmptyTile()
        {
            string et = @"   |";
            return et;
        }

        public static string NumberTile(string numberOfAdjacentMines)
        {
            var num = Convert.ToInt32(numberOfAdjacentMines);
            string nt = string.Format(" {0} |", num);
            return nt;
        }

        public static string MarkedTile()
        {
            string mt = @" ? |";
            return mt;
        }

        public static string BombTile()
        {
            string bt = @"~X~|";
            return bt;
        }
    }
}
