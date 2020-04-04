using System;
namespace MinesweeperSK.Visuals
{
    public class GameboardVisuals
    {
        public static string GameboardHandler(string dificulty, string[] boardState)
        {
            string theBoard = "not clean data";

            if (dificulty == "easy")
            {
                theBoard = EasyBoard(boardState);
            }
            if (dificulty == "regular")
            {
                theBoard = NormalBoard(boardState);
            }
            if (dificulty == "hard")
            {
                theBoard = HardBoard(boardState);
            }

            return theBoard;
        }


        public static string EasyBoard(string[] boardState)
        {
            string theBoard = string.Format
                (
                    "    a   b   c   d   e  " + "\n" +
                    "   --------------------" + "\n" +
                    "1 |{0}{1}{2}{3}{4}" + "\n" +
                    "   --------------------" + "\n" +
                    "2 |{5}{6}{7}{8}{9}" + "\n" +
                    "   --------------------" + "\n" +
                    "3 |{10}{11}{12}{13}{14}" + "\n" +
                    "   --------------------" + "\n" +
                    "4 |{15}{16}{17}{18}{19}" + "\n" +
                    "   --------------------" + "\n" +
                    "5 |{20}{21}{22}{23}{24}" + "\n" +
                    "   --------------------",
                    boardState[0], boardState[1], boardState[2], boardState[3], boardState[4], boardState[5], boardState[6], boardState[7], boardState[8], boardState[9], boardState[10], boardState[11], boardState[12], boardState[13], boardState[14], boardState[15], boardState[16], boardState[17], boardState[18], boardState[19], boardState[20], boardState[21], boardState[22], boardState[23], boardState[24]
                );

            return theBoard;
        }


        public static string NormalBoard(string[] boardState)
        {
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

            return theBoard;
        }


        public static string HardBoard(string[] boardState)
        {
            string theBoard = string.Format
                (
                    "    a   b   c   d   e   f   g   h   i   j   k   l   m   n   o   p  " + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "1 |{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "2 |{16}{17}{18}{19}{20}{21}{22}{23}{24}{25}{26}{27}{28}{29}{30}{31}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "3 |{32}{33}{34}{35}{36}{37}{38}{39}{40}{41}{42}{43}{44}{45}{46}{47}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "4 |{48}{49}{50}{51}{52}{53}{54}{55}{56}{57}{58}{59}{60}{61}{62}{63}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "5 |{64}{65}{66}{67}{68}{69}{70}{71}{72}{73}{74}{75}{76}{77}{78}{79}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "6 |{80}{81}{82}{83}{84}{85}{86}{87}{88}{89}{90}{91}{92}{93}{94}{95}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "7 |{96}{97}{98}{99}{100}{101}{102}{103}{104}{105}{106}{107}{108}{109}{110}{111}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "8 |{112}{113}{114}{115}{116}{117}{118}{119}{120}{121}{122}{123}{124}{125}{126}{127}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "9 |{128}{129}{130}{131}{132}{133}{134}{135}{136}{137}{138}{139}{140}{141}{142}{143}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "10|{144}{145}{146}{147}{148}{149}{150}{151}{152}{153}{154}{155}{156}{157}{158}{159}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "11|{160}{161}{162}{163}{164}{165}{166}{167}{168}{169}{170}{171}{172}{173}{174}{175}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "12|{176}{177}{178}{179}{180}{181}{182}{183}{184}{185}{186}{187}{188}{189}{190}{191}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "13|{192}{193}{194}{195}{196}{197}{198}{199}{200}{201}{202}{203}{204}{205}{206}{207}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "14|{208}{209}{210}{211}{212}{213}{214}{215}{216}{217}{218}{219}{220}{221}{222}{223}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "15|{224}{225}{226}{227}{228}{229}{230}{231}{232}{233}{234}{235}{236}{237}{238}{239}" + "\n" +
                    "   ----------------------------------------------------------------" + "\n" +
                    "16|{240}{241}{242}{243}{244}{245}{246}{247}{248}{249}{250}{251}{252}{253}{254}{255}" + "\n" +
                    "   ----------------------------------------------------------------",
                    boardState[0], boardState[1], boardState[2], boardState[3], boardState[4], boardState[5], boardState[6], boardState[7], boardState[8], boardState[9], boardState[10], boardState[11], boardState[12], boardState[13], boardState[14], boardState[15], boardState[16], boardState[17], boardState[18], boardState[19], boardState[20], boardState[21], boardState[22], boardState[23], boardState[24], boardState[25], boardState[26], boardState[27], boardState[28], boardState[29], boardState[30], boardState[31], boardState[32], boardState[33], boardState[34], boardState[35], boardState[36], boardState[37], boardState[38], boardState[39], boardState[40], boardState[41], boardState[42], boardState[43], boardState[44], boardState[45], boardState[46], boardState[47], boardState[48], boardState[49], boardState[50], boardState[51], boardState[52], boardState[53], boardState[54], boardState[55], boardState[56], boardState[57], boardState[58], boardState[59], boardState[60], boardState[61], boardState[62], boardState[63], boardState[64], boardState[65], boardState[66], boardState[67], boardState[68], boardState[69], boardState[70], boardState[71], boardState[72], boardState[73], boardState[74], boardState[75], boardState[76], boardState[77], boardState[78], boardState[79], boardState[80], boardState[81], boardState[82], boardState[83], boardState[84], boardState[85], boardState[86], boardState[87], boardState[88], boardState[89], boardState[90], boardState[91], boardState[92], boardState[93], boardState[94], boardState[95], boardState[96], boardState[97], boardState[98], boardState[99], boardState[100], boardState[101], boardState[102], boardState[103], boardState[104], boardState[105], boardState[106], boardState[107], boardState[108], boardState[109], boardState[110], boardState[111], boardState[112], boardState[113], boardState[114], boardState[115], boardState[116], boardState[117], boardState[118], boardState[119], boardState[120], boardState[121], boardState[122], boardState[123], boardState[124], boardState[125], boardState[126], boardState[127], boardState[128], boardState[129], boardState[130], boardState[131], boardState[132], boardState[133], boardState[134], boardState[135], boardState[136], boardState[137], boardState[138], boardState[139], boardState[140], boardState[141], boardState[142], boardState[143], boardState[144], boardState[145], boardState[146], boardState[147], boardState[148], boardState[149], boardState[150], boardState[151], boardState[152], boardState[153], boardState[154], boardState[155], boardState[156], boardState[157], boardState[158], boardState[159], boardState[160], boardState[161], boardState[162], boardState[163], boardState[164], boardState[165], boardState[166], boardState[167], boardState[168], boardState[169], boardState[170], boardState[171], boardState[172], boardState[173], boardState[174], boardState[175], boardState[176], boardState[177], boardState[178], boardState[179], boardState[180], boardState[181], boardState[182], boardState[183], boardState[184], boardState[185], boardState[186], boardState[187], boardState[188], boardState[189], boardState[190], boardState[191], boardState[192], boardState[193], boardState[194], boardState[195], boardState[196], boardState[197], boardState[198], boardState[199], boardState[200], boardState[201], boardState[202], boardState[203], boardState[204], boardState[205], boardState[206], boardState[207], boardState[208], boardState[209], boardState[210], boardState[211], boardState[212], boardState[213], boardState[214], boardState[215], boardState[216], boardState[217], boardState[218], boardState[219], boardState[220], boardState[221], boardState[222], boardState[223], boardState[224], boardState[225], boardState[226], boardState[227], boardState[228], boardState[229], boardState[230], boardState[231], boardState[232], boardState[233], boardState[234], boardState[235], boardState[236], boardState[237], boardState[238], boardState[239], boardState[240], boardState[241], boardState[242], boardState[243], boardState[244], boardState[245], boardState[246], boardState[247], boardState[248], boardState[249], boardState[250], boardState[251], boardState[252], boardState[253], boardState[254], boardState[255]
                );

            return theBoard;
        }
    }
}
