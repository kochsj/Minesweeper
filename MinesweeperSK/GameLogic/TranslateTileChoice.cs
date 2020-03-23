using System;

namespace MinesweeperSK.GameLogic
{
    public class TranslateTileChoice
    {
        private enum Alphabet
        {
            a = 0,
            b = 1,
            c = 2,
            d = 3,
            e = 4,
            f = 5,
            g = 6,
            h = 7,
            i = 8
        }

        public static int Translate(string tileChoice)
        {
            char firstChar = tileChoice[0];
            Console.WriteLine("first char: " + firstChar);
            char secondChar = tileChoice[1];
            Console.WriteLine("second char: " + secondChar);

            int firstInt = (int)firstChar;
            int secondInt = (int)secondChar;
            Console.WriteLine(string.Format("firstint: {0}, secondInt: {1}", firstInt, secondInt));

            int tileToChange = ((firstInt - 1) * 9) + secondInt;
            Console.WriteLine(tileToChange);
            return tileToChange;
        }
    }
}
