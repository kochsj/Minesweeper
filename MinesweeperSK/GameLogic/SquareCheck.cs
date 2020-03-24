using System;
using System.Collections.Generic;
using MinesweeperSK.Visuals;

namespace MinesweeperSK.GameLogic
{
    public class SquareCheck
    {

        public static void SquareCheckHandler(string tileChoice)
        {
            int tileToChange = TranslateTileChoice.Translate(tileChoice);

            var isBomb = CheckIfTileSelectionIsBomb(tileToChange);
            if (isBomb == true)
            {
                // end the game
                var bombTile = new Dictionary<int, string>();
                bombTile.Add(tileToChange, Tiles.BombTile());
                ModifyTheTiles(bombTile);
                return;
            }

            var adjacentTiles = CheckAdjacentTilesForBombs(tileToChange);

            ModifyTheTiles(adjacentTiles);
        }

        public static bool CheckIfTileSelectionIsBomb(int tileChoice)
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

        public static Dictionary<int,string> CheckAdjacentTilesForBombs(int tileChoiceFromPlayer)
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

            adjRecurse(tileChoiceFromPlayer, dictOfTileIDAndTileTypeForUse, visitedTiles);

            return dictOfTileIDAndTileTypeForUse;



            void adjRecurse(int tileChoice, Dictionary<int, string> dictOfTileIDAndTileType, List<int> alreadyVisitedTiles)
            {
                int numberOfAdjBombs = 0;
                var adjDictOfValidTiles = new Dictionary<string, int>();

                //1
                var eWDict = EastWestAdjacencyHandler(tileChoice);
                foreach (KeyValuePair<string,int> direction in eWDict)
                {
                    adjDictOfValidTiles.Add(direction.Key, direction.Value);
                    //if (direction.Value != 90) { adjDictOfValidTiles.Add(direction.Key, direction.Value); }
                }

                //2
                numberOfAdjBombs += EastWestBombCheckHandler(adjDictOfValidTiles);

                //3
                var nSDict = NorthSouthAdjacencyHandler(tileChoice);
                foreach (KeyValuePair<string,int> direction in nSDict)
                {
                    adjDictOfValidTiles.Add(direction.Key, direction.Value);
                    //if (direction.Value != 90) { adjDictOfValidTiles.Add(direction.Key, direction.Value); }
                }

                //4
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles);

                //5
                nSDict = NorthSouthAdjacencyHandler(adjDictOfValidTiles["west"]);
                foreach (KeyValuePair<string, int> direction in nSDict)
                {
                    adjDictOfValidTiles[direction.Key] = direction.Value;
                    //adjDictOfValidTiles.Add(direction.Key, direction.Value);
                }

                //6
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles);

                //7
                nSDict = NorthSouthAdjacencyHandler(adjDictOfValidTiles["east"]);
                foreach (KeyValuePair<string, int> direction in nSDict)
                {
                    adjDictOfValidTiles[direction.Key] = direction.Value;
                    //adjDictOfValidTiles.Add(direction.Key, direction.Value);
                }

                //8
                numberOfAdjBombs += NorthSouthBombCheckHandler(adjDictOfValidTiles);

                //9
                if (numberOfAdjBombs == 0)
                {
                    foreach (KeyValuePair<string,int> tile in adjDictOfValidTiles)
                    {
                        bool haveNotVisited = CheckIfNotVisited(tile.Value, alreadyVisitedTiles);

                        if (tile.Value <= 80 & haveNotVisited) //meaning it is valid tile
                        {
                            alreadyVisitedTiles.Add(tile.Value);
                            var tileType = getTileType(tile.Value, numberOfAdjBombs);
                            dictOfTileIDAndTileType.Add(tile.Value, tileType[tile.Value]);
                            Console.WriteLine(string.Format("Added {0}", tile.Value));
                            Console.WriteLine(string.Format("======Checking {0}, Tile {1}", tile.Key, tile.Value));
                            adjRecurse(tile.Value, dictOfTileIDAndTileType, alreadyVisitedTiles);
                        }
                    }
                }
                bool haveNotVisited2 = CheckIfNotVisited(tileChoice, alreadyVisitedTiles);

                if (haveNotVisited2)
                {
                    alreadyVisitedTiles.Add(tileChoice);
                    Console.WriteLine(string.Format("Added outside {0}", tileChoice));
                    var tileType = getTileType(tileChoice, numberOfAdjBombs);
                    dictOfTileIDAndTileType.Add( tileChoice, tileType[tileChoice] );
                }
                

            }


            bool CheckIfNotVisited(int tile, List<int> list)
            {
                foreach (int tileNum in list)
                {
                    if (tile == tileNum) { return false; }
                }
                return true;
            }


            Dictionary<int,string> getTileType(int tileChoice, int numberOfAdjBombs)
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

            int NorthSouthBombCheckHandler(Dictionary<string,int> adjDictOfValidTiles)
            {
                int numberOfAdjBombs = 0;
                bool northIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["north"]);
                bool southIsBomb = CheckIfTileSelectionIsBomb(adjDictOfValidTiles["south"]);
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

            Dictionary<string, int> NorthSouthAdjacencyHandler(int tileChoice)
            {
                var adjDict = new Dictionary<string, int>();

                int north = getNorth(tileChoice);
                int south = getSouth(tileChoice);
                adjDict.Add("north", north);
                adjDict.Add("south", south);

                return adjDict;
            }


            int getNorth(int tileChoice)
            {
                if (tileChoice >= 9) { return tileChoice - 9; }
                else { return 90; }
            }
            int getSouth(int tileChoice)
            {
                if (tileChoice <= 71) { return tileChoice + 9; }
                else { return 90; }
            }
            int getEast(int tileChoice)
            {
                if ((tileChoice + 1) % 9 != 0) { return tileChoice + 1; }
                else { return 90; }
            }
            int getWest(int tileChoice)
            {
                if (tileChoice % 9 != 0) { return tileChoice - 1; }
                else { return 90; }
            }

        }

        public static Dictionary<int, string> SquaresToModify()
        {
            // will return the squareID# : new tileString being updated
            var squareDict = new Dictionary<int, string>();
            squareDict.Add(30, Tiles.NumberTile(1));
            squareDict.Add(80, Tiles.NumberTile(3));
            return squareDict;
        }


        public static void ModifyTheTiles(Dictionary<int,string> squaresToModify)
        {
            Gameboard.UpdateTheBoardState(squaresToModify);
            Gameboard.PrintTheBoard();
        }


    }

}
