using System;
using System.Collections.Generic;
using MinesweeperSK.GameLogic;

namespace MinesweeperSK.GameLogic
{
    public class SquareCheck
    {
        /// <summary>
        /// Checks the current Gameboard tile matrix for bombs, adjacent bombs, or adjacent empty tiles.
        /// </summary>

        public static Dictionary<int,string> SquareCheckHandler(string tileChoice)
        {
            int tileToChange = 0;

            if (tileChoice.Length == 3)
            {
                tileToChange = TranslateTileChoice.Translate(tileChoice, 3);
            }
            else
            {
                tileToChange = TranslateTileChoice.Translate(tileChoice, 2);
            }

            var isBomb = CheckIfTileSelectionIsBomb(tileToChange);

            if (isBomb == true)
            {
                // end the game
                var bombTile = new Dictionary<int, string>();
                bombTile.Add(tileToChange, Tiles.BombTile());
                return bombTile;
            }

            var adjacentTiles = CheckAdjacentTilesForBombs(tileToChange);

            return adjacentTiles;
        }


        private static bool CheckIfTileSelectionIsBomb(int tileChoice)
        {
            int[] bombTiles = Matrix.RetrieveTileNumbers();

            foreach (int tile in bombTiles)
            {
                if (tileChoice == tile)
                {
                    return true;
                }
            }
            return false;
        }


        private static Dictionary<int,string> CheckAdjacentTilesForBombs(int tileChoiceFromPlayer)
        {
            // 1) Grab E/W tiles (if exist) and save them
            // 2) Check E/W tiles if they are bombs; increment numberOfAdjBombs
            // 3) Grab N/S tiles (if exist) for orig tileChoice and save them
            // 4) Check N/S tiles if they are bombs; increment numberOfAdjBombs
            // 5) Grab N/S tiles (if exist) for west and override old north south
            // 6) Check new N/S tiles for bombs
            // 7) Repeat 5 for east
            // 8) Repeat 6 for east
            // 9) Check if numberOfAdjBombs > 0; if it isn't we call CheckAdjacentTilesForBombs for every adjacent tile
            // 10) Return number of adj bombs for given tile
            var dictOfTileIDAndTileTypeForUse = new Dictionary<int, string>();
            var visitedTiles = new List<int>();
            int boardHeight = 0;
            int boardWidth = 0;


            if (BoardState.gameDifficulty == "easy") { boardHeight = 19; boardWidth = 5; }
            if (BoardState.gameDifficulty == "regular") { boardHeight = 71; boardWidth = 9; }
            if (BoardState.gameDifficulty == "hard") { boardHeight = 239; boardWidth = 16; }

            adjRecurse(tileChoiceFromPlayer, dictOfTileIDAndTileTypeForUse, visitedTiles);

            return dictOfTileIDAndTileTypeForUse;



            void adjRecurse(int tileChoice, Dictionary<int, string> dictOfTileIDAndTileType, List<int> alreadyVisitedTiles)
            {
                alreadyVisitedTiles.Add(tileChoice);
                int numberOfAdjBombs = 0;
                var adjDictOfValidTiles = new Dictionary<string, int>();

                //1
                var eWDict = EastWestAdjacencyHandler(tileChoice);
                foreach (KeyValuePair<string,int> direction in eWDict)
                {
                    adjDictOfValidTiles.Add(direction.Key, direction.Value);
                }

                //2
                numberOfAdjBombs += EastWestBombCheckHandler(adjDictOfValidTiles);

                //3
                var nSDict = NorthSouthAdjacencyHandler(tileChoice, "org");
                foreach (KeyValuePair<string,int> direction in nSDict)
                {
                    adjDictOfValidTiles.Add(direction.Key, direction.Value);
                }

                //4
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles, "org");

                //5
                nSDict = NorthSouthAdjacencyHandler(adjDictOfValidTiles["west"], "w");
                foreach (KeyValuePair<string, int> direction in nSDict)
                {
                    adjDictOfValidTiles[direction.Key] = direction.Value;
                }

                //6
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles, "w");

                //7
                nSDict = NorthSouthAdjacencyHandler(adjDictOfValidTiles["east"], "e");
                foreach (KeyValuePair<string, int> direction in nSDict)
                {
                    adjDictOfValidTiles[direction.Key] = direction.Value;
                }

                //8
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles, "e");

                //9
                if (numberOfAdjBombs == 0)
                {
                    foreach (KeyValuePair<string,int> tile in adjDictOfValidTiles)
                    {
                        bool haveNotVisited = CheckIfNotVisited(tile.Value, alreadyVisitedTiles);

                        if (tile.Value >= 0 & haveNotVisited) //meaning it is valid tile
                        {
                            adjRecurse(tile.Value, dictOfTileIDAndTileType, alreadyVisitedTiles);
                            //Console.WriteLine(string.Format("Added and searching {0}", tile.Value));
                        }
                    }
                }

                var tileType = GetTileType(tileChoice, numberOfAdjBombs);
                dictOfTileIDAndTileType.Add( tileChoice, tileType[tileChoice] );
                //Console.WriteLine(string.Format("Adding to final dict: tile {0}", tileChoice));
            }



    //////////////////////////////////////
    /// Helper Functions
    //////////////////////////////////////
            bool CheckIfNotVisited(int tile, List<int> list)
            {
                foreach (int tileNum in list)
                {
                    if (tile == tileNum) { return false; }
                }
                return true;
            }


            Dictionary<int,string> GetTileType(int tileChoice, int numberOfAdjBombs)
            {
                var dict = new Dictionary<int, string>();
                if (numberOfAdjBombs == 0)
                {
                    dict.Add(tileChoice, Tiles.EmptyTile());
                }
                else { dict.Add(tileChoice, Tiles.NumberTile(numberOfAdjBombs)); }

                return dict;
            }

            int EastWestBombCheckHandler(Dictionary<string, int> adjDictOfValidTiles)
            {
                int numberOfAdjBombs = 0;
                bool eastIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["east"]);
                bool westIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["west"]);
                if (eastIsBomb) { numberOfAdjBombs++; }
                if (westIsBomb) { numberOfAdjBombs++; }

                return numberOfAdjBombs;
            }

            int NorthSouthBombCheckHandler(Dictionary<string,int> adjDictOfValidTiles, string identifier)
            {
                int numberOfAdjBombs = 0;
                bool northIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["north"+identifier]);
                bool southIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["south"+identifier]);
                if (northIsBomb) { numberOfAdjBombs++; }
                if (southIsBomb) { numberOfAdjBombs++; }

                return numberOfAdjBombs;
            }

            Dictionary<string, int> EastWestAdjacencyHandler(int tileChoice)
            {
                var adjDict = new Dictionary<string, int>();

                int east = getEast(tileChoice);
                int west = getWest(tileChoice);
                adjDict.Add("east", east);
                adjDict.Add("west", west);

                return adjDict;
            }

            Dictionary<string, int> NorthSouthAdjacencyHandler(int tileChoice, string identifier)
            {
                var adjDict = new Dictionary<string, int>();

                int north = getNorth(tileChoice);
                int south = getSouth(tileChoice);
                adjDict.Add("north"+identifier, north);
                adjDict.Add("south"+identifier, south);

                return adjDict;
            }


            int getNorth(int tileChoice)
            {
                if (tileChoice >= boardWidth) { return tileChoice - boardWidth; }
                else { return -1; }
            }
            int getSouth(int tileChoice)
            {
                if (tileChoice <= boardHeight) { return tileChoice + boardWidth; }
                else { return -1; }
            }
            int getEast(int tileChoice)
            {
                if ((tileChoice + 1) % boardWidth != 0) { return tileChoice + 1; }
                else { return -1; }
            }
            int getWest(int tileChoice)
            {
                if (tileChoice % boardWidth != 0) { return tileChoice - 1; }
                else { return -1; }
            }

        }

    }

}
