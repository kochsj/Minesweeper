using System;
namespace MinesweeperSK.GameLogic
{
    public class UserSelection
    {
        public static string SelectTile()
        {
            var validNumbers = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var validLetters = new char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            while (true)
            {
                Console.WriteLine("Enter tile (examples: 3d or 9a)");

                string response = Console.ReadLine();

                if (response.Length != 2)
                {
                    Console.WriteLine(string.Format("{0} is invalid[0]. Please enter a valid tile.", response));
                }
                else if (!Array.Exists(validNumbers, element => element == response[0]))
                {
                    Console.WriteLine(string.Format("{0} is invalid[1]. Please enter a valid tile.", response));
                }
                else if (!Array.Exists(validLetters, element => element == response[1]))
                {
                    Console.WriteLine(string.Format("{0} is invalid[2]. Please enter a valid tile.", response));
                }
                else
                {
                    //Console.WriteLine(string.Format("{0} is a valid response", response));
                    return response;
                }
            }
        }
    }
}
