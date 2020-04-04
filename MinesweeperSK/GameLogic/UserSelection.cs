using System;
using System.Collections.Generic;
using MinesweeperSK.GameLogic;

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

                if (isValid == true & response.Length == 3)
                {
                    int tileID = TranslateTileChoice.Translate(response, 3);
                    MarkTile(tileID);
                }
                else
                {
                    int tileID = TranslateTileChoice.Translate(response, 2);
                    MarkTile(tileID);
                }
            }
        }

        private static void MarkTile(int tileID)
        {
            string tileState = BoardState.GetCurrentTileState(tileID);
            var tileDict = new Dictionary<int, string>();

            if (tileState == Tiles.UnvisitedTile())
            {
                tileDict.Add(tileID, Tiles.MarkedTile());
            }
            if (tileState == Tiles.MarkedTile())
            {
                tileDict.Add(tileID, Tiles.UnvisitedTile());
            }

            BoardState.UpdateTheBoardState(tileDict);
        }


        private static bool ValidateTileSelection(string response)
        {
            string[] validNumbers = new string[1];
            char[] validLetters = new char[1];
            string firstChar = Char.ToString(response[0]);


            if (BoardState.gameDifficulty == "easy")
            {
                validNumbers = new string[5] { "1", "2", "3", "4", "5" };
                validLetters = new char[5] { 'a', 'b', 'c', 'd', 'e' };
            }
            if (BoardState.gameDifficulty == "regular")
            {
                validNumbers = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                validLetters = new char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
            }
            if (BoardState.gameDifficulty == "hard")
            {
                validNumbers = new string[16] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
                validLetters = new char[16] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
            }


            if (response.Length == 3 & BoardState.gameDifficulty == "hard")
            {
                string secondChar = Char.ToString(response[1]);
                string twoDigits = firstChar + secondChar;

                if (!Array.Exists(validNumbers, element => element == twoDigits))
                {
                    Console.WriteLine(string.Format("{0} is invalid[1]. Please enter a valid tile.", response));
                }
                else if (!Array.Exists(validLetters, element => element == response[2]))
                {
                    Console.WriteLine(string.Format("{0} is invalid[2]. Please enter a valid tile.", response));
                }
                else
                {
                    return true;
                }
            }

            else if (response.Length != 2)
            {
                Console.WriteLine(string.Format("{0} is invalid[0]. Please enter a valid tile.", response));
            }
            else if (!Array.Exists(validNumbers, element => element == firstChar))
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
