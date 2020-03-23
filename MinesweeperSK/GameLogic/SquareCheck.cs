using System;
using System.Collections.Generic;
using MinesweeperSK.Visuals;

namespace MinesweeperSK.GameLogic
{
    public class SquareCheck
    {
        public static Dictionary<int, string> SquaresToModify()
        {
            // will return the squareID# : new tileString being updated
            var squareDict = new Dictionary<int, string>();
            squareDict.Add(30, Tiles.NumberTile(1));
            squareDict.Add(80, Tiles.NumberTile(3));
            return squareDict;
        }

        public static void ModifyTheTiles()
        {
            Gameboard.UpdateTheBoardState(SquaresToModify());
            Gameboard.PrintTheBoard();
        }
    }

}
