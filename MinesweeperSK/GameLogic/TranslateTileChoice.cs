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
            char secondChar = tileChoice[1];

            Alphabet secondEnum = (Alphabet)Enum.Parse(typeof(Alphabet), Char.ToString(secondChar));

            int firstInt = (int)Char.GetNumericValue(firstChar);
            int secondInt = Convert.ToInt32(secondEnum);

            var tileToChange = ((firstInt - 1) * 9) + secondInt;
            return tileToChange;
        }
    }
}
