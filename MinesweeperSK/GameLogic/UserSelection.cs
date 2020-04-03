using System;
using System.Collections.Generic;
using MinesweeperSK.Visuals;

namespace MinesweeperSK.GameLogic
{
    public class UserSelection
    {


        public static string SelectTile()
        {
            bool isValid = false;

            while (true)
            {
                Console.WriteLine("Enter tile to select (examples: 3d or 9a)");
                Console.WriteLine("Enter 'mark' to mark tiles with '?'");

                string response = Console.ReadLine();

                ClearCurrentConsoleLine(Console.CursorTop, 3);

                if (response.ToLower() == "mark")
                {
                    string tileToMark = MarkerMode();
                    if (tileToMark != "n/a")
                    {
                        isValid = true;
                        response = tileToMark;
                    }
                    return "marked";
                }
                else
                {
                    isValid = ValidateTileSelection(response);
                }

                if (isValid == true)
                {
                    return response;
                }
                
            }
        }


        private static string MarkerMode()
        {
            bool isValid = false;

            while (true)
            {
                Console.WriteLine("================ MARKER MODE ===================");
                Console.WriteLine("Enter tile to mark with '?' (examples: 3d or 9a)");
                Console.WriteLine("Enter 'mark' again to exit marker mode.");

                string response = Console.ReadLine();

                ClearCurrentConsoleLine(Console.CursorTop, 4);


                if (response.ToLower() == "mark")
                {
                    return "n/a";
                }

                isValid = ValidateTileSelection(response);

                if (isValid == true)
                {
                    int tileID = TranslateTileChoice.Translate(response);
                    MarkTile(tileID);
                }
            }
        }

        private static void MarkTile(int tileID)
        {
            string tileState = Gameboard.GetCurrentTileState(tileID);
            var tileDict = new Dictionary<int, string>();

            if (tileState == Tiles.UnvisitedTile())
            {
                tileDict.Add(tileID, Tiles.MarkedTile());
            }
            if (tileState == Tiles.MarkedTile())
            {
                tileDict.Add(tileID, Tiles.UnvisitedTile());
            }

            Gameboard.UpdateTheBoardState(tileDict);
            Gameboard.PrintTheBoard(false);
        }


        private static bool ValidateTileSelection(string response)
        {
            var validNumbers = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var validLetters = new char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            if (response.Length != 2)
            {
                Console.WriteLine(string.Format("{0} is invalid[0]. Please enter a valid tile.", response));
            }
            else if (!Array.Exists(validNumbers, element => element == response[0]))
            {
                Console.WriteLine(string.Format("{0} is invalid[1]. Please enter a valid tile.", response));
            }
            else if (!Array.Exists(validLetters, element => element == response[1]))
            {
                Console.WriteLine(string.Format("{0} is invalid[2]. Please enter a valid tile.", response));
            }
            else
            {
                return true;
            }

            Console.ReadLine();
            ClearCurrentConsoleLine(Console.CursorTop, 2);

            return false;
        }

        public static void ClearCurrentConsoleLine(int currentLineCursor, int numberOfLinesToClear)
        {
            for (int i = 0; i < numberOfLinesToClear; i++)
            {
                Console.SetCursorPosition(0, currentLineCursor - numberOfLinesToClear + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, currentLineCursor - numberOfLinesToClear);
        }
    }
}
