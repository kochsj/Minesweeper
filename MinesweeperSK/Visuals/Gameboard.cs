using System;
using System.Collections.Generic;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK.Visuals
{
    public class Gameboard
    {
        private static string[] boardState = new string[81];

        public static void InitializeBoardState()
        {
            Matrix.GenerateMatrix();

            for (int i = 0; i < boardState.Length; i++)
            {
                boardState[i] = Tiles.UnvisitedTile();
            }
        }

        public static void UpdateTheBoardState(Dictionary<int, string> tileDict)
        {
            foreach (KeyValuePair<int, string> tileToChange in tileDict)
            {
                Console.WriteLine(string.Format("changing tile: {0}, with: {1}", tileToChange.Key, tileToChange.Value ));
                if (tileToChange.Key <= 80)
                {
                    boardState[tileToChange.Key] = tileToChange.Value;
                    Console.WriteLine(string.Format("officially changed tile: {0}", tileToChange.Key));
                }
            }
        }

        public static void PrintTheBoard()
        {
            Console.Clear();
            string theBoard = string.Format
                (
                    "    a   b   c   d   e   f   g   h   i  " + "\n" +
                    "   ------------------------------------" + "\n" +
                    "1 |{0}{1}{2}{3}{4}{5}{6}{7}{8}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "2 |{9}{10}{11}{12}{13}{14}{15}{16}{17}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "3 |{18}{19}{20}{21}{22}{23}{24}{25}{26}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "4 |{27}{28}{29}{30}{31}{32}{33}{34}{35}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "5 |{36}{37}{38}{39}{40}{41}{42}{43}{44}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "6 |{45}{46}{47}{48}{49}{50}{51}{52}{53}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "7 |{54}{55}{56}{57}{58}{59}{60}{61}{62}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "8 |{63}{64}{65}{66}{67}{68}{69}{70}{71}" + "\n" +
                    "   ------------------------------------" + "\n" +
                    "9 |{72}{73}{74}{75}{76}{77}{78}{79}{80}" + "\n" +
                    "   ------------------------------------",
                    boardState[0], boardState[1], boardState[2], boardState[3], boardState[4], boardState[5], boardState[6], boardState[7], boardState[8], boardState[9], boardState[10], boardState[11], boardState[12], boardState[13], boardState[14], boardState[15], boardState[16], boardState[17], boardState[18], boardState[19], boardState[20], boardState[21], boardState[22], boardState[23], boardState[24], boardState[25], boardState[26], boardState[27], boardState[28], boardState[29], boardState[30], boardState[31], boardState[32], boardState[33], boardState[34], boardState[35], boardState[36], boardState[37], boardState[38], boardState[39], boardState[40], boardState[41], boardState[42], boardState[43], boardState[44], boardState[45], boardState[46], boardState[47], boardState[48], boardState[49], boardState[50], boardState[51], boardState[52], boardState[53], boardState[54], boardState[55], boardState[56], boardState[57], boardState[58], boardState[59], boardState[60], boardState[61], boardState[62], boardState[63], boardState[64], boardState[65], boardState[66], boardState[67], boardState[68], boardState[69], boardState[70], boardState[71], boardState[72], boardState[73], boardState[74], boardState[75], boardState[76], boardState[77], boardState[78], boardState[79], boardState[80]
                );
            Console.WriteLine(theBoard);
        }
        
        public static void PrintTheBoardDepracated()
        {
            Console.WriteLine(@"    a   b   c   d   e   f   g   h   i  ");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"1 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"2 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"3 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"4 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"5 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"6 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"7 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"8 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
            Console.WriteLine(@"9 | * | * | * | * | * | * | * | * | * |");
            Console.WriteLine(@"   ------------------------------------");
        }
    }
}
