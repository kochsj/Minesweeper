using System;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK.Text
{
    public class GameOver
    {
        public static void PrintGameOver()
        {
            Console.WriteLine("GAME OVER");
            // TODO: show all bomb tiles
            // TODO: Print Text.GameOver (with time, stats, etc)
            Console.ReadLine();
        }

        public static void EraseGameOver()
        {
            UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 2);
        }
    }
}
