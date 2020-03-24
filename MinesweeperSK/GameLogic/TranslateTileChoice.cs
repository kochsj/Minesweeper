using System;

namespace MinesweeperSK.GameLogic
{
    public class TranslateTileChoice
    {
        enum Alphabet
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
        };

        public static int Translate(string tileChoice)
        {
            
            char firstChar = tileChoice[0];
            //Console.WriteLine("first char: " + firstChar);
            char secondChar = tileChoice[1];
            //Console.WriteLine("second char: " + secondChar);

            Alphabet secondEnum = (Alphabet)Enum.Parse(typeof(Alphabet), Char.ToString(secondChar));
            //Console.WriteLine("second enum: " + secondEnum);

            int firstInt = (int)Char.GetNumericValue(firstChar);
            int secondInt = Convert.ToInt32(secondEnum);
            //Console.WriteLine(string.Format("firstint: {0}, secondInt: {1}", firstInt, secondInt));

            var tileToChange = ((firstInt - 1) * 9) + secondInt;
            //Console.WriteLine(tileToChange);
            return tileToChange;
        }
    }
}
