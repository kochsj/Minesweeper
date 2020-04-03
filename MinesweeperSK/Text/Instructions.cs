using System;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK.Text
{
    public class Instructions
    {


        public static void InstructionHandler()
        {
            StartingScreen.EraseStartingScreen();

            PrintInstructions();

            EraseInstructions();

            StartingScreen.PrintStartingScreen();

        }


        public static void PrintInstructions()
        {
            Console.WriteLine
            (
                "========================================" + "\n" +
                "============= INSTRUCTIONS =============" + "\n" +
                "\n" +
                "To win at Minesweeper you must clear the" + "\n" +
                "'minefield' of all the mines." + "\n" +
                "\n" +
                "Be careful though, one mistake and you " + "\n" +
                "could hit a mine... (not a pretty sight)" + "\n" +
                "\n" +
                "In Minesweeper, every tile on the" + "\n" +
                "minefield is either a mine or it is not" + "\n" +
                "a mine. Luckily, selecting a tile will " + "\n" +
                "reveal how many mines are touching that" + "\n" +
                "tile. Thinking strategically, you can " + "\n" +
                "narrow down the tiles that could be " + "\n" +
                "possibly be mines." + "\n" +
                "\n" +
                "Mark the tiles that you think are mines" + "\n" +
                "using the 'MARKER MODE' option in game." + "\n" +
                "\n"+
                "When all tiles have been visited, meaning" + "\n" +
                "you checked them or marked them (correctly)" + "\n" +
                "you win!" + "\n" +
                "\n"
            );

            Console.WriteLine("ENTER TO CONTINUE");
            Console.ReadLine();
        }


        public static void EraseInstructions()
        {
            UserSelection.ClearCurrentConsoleLine(Console.CursorTop, 27);
        }
    }
}
