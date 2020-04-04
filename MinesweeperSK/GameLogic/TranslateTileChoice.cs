using System;

namespace MinesweeperSK.GameLogic
{
    public class TranslateTileChoice
    {
        enum Alphabet
        {
            a,
            b,
            c,
            d,
            e,
            f,
            g,
            h,
            i,
            j,
            k,
            l,
            m,
            n,
            o,
            p
        };
        
        public static int Translate(string tileChoice, int responseLength)
        {
            int boardWidth = 0;


            if (BoardState.gameDifficulty == "easy") { boardWidth = 5; }
            if (BoardState.gameDifficulty == "regular") { boardWidth = 9; }
            if (BoardState.gameDifficulty == "hard") { boardWidth = 16; }

            char firstChar = tileChoice[0];
            char secondChar = tileChoice[1];
            Alphabet letterEnum = Alphabet.a;
            int firstInt = 0;

            if (responseLength == 2)
            {
                letterEnum = (Alphabet)Enum.Parse(typeof(Alphabet), Char.ToString(secondChar));
                firstInt = (int)Char.GetNumericValue(firstChar);
            }
            if (responseLength == 3)
            {
                char thirdChar = tileChoice[2];
                letterEnum = (Alphabet)Enum.Parse(typeof(Alphabet), Char.ToString(thirdChar));
                string twoDigits = Char.ToString(firstChar) + Char.ToString(secondChar);

                firstInt = Int32.Parse(twoDigits);
            }


            int secondInt = Convert.ToInt32(letterEnum);

            var tileToChange = ((firstInt - 1) * boardWidth) + secondInt;

            return tileToChange;
        }
    }
}
