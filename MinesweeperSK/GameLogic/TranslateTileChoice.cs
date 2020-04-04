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
        
        public static int Translate(string tileChoice)
        {
            int boardWidth = 0;

            if (BoardState.gameDifficulty == "easy") { boardWidth = 5; }
            if (BoardState.gameDifficulty == "regular") { boardWidth = 9; }
            if (BoardState.gameDifficulty == "hard") { boardWidth = 16; }

            char firstChar = tileChoice[0];
            char secondChar = tileChoice[1];

            Alphabet secondEnum = (Alphabet)Enum.Parse(typeof(Alphabet), Char.ToString(secondChar));

            int firstInt = (int)Char.GetNumericValue(firstChar);
            int secondInt = Convert.ToInt32(secondEnum);

            var tileToChange = ((firstInt - 1) * boardWidth) + secondInt;
            return tileToChange;
        }
    }
}
