using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inGame = true;
            while (inGame)
            {
                Console.WriteLine("Welcome to Dungeon Explorer");
                Console.WriteLine("Start a new game - S");
                Console.WriteLine("Quit game - Q");
                bool validInput = false;
                while (validInput == false)
                {
                    string input = Console.ReadLine();
                    if (input != "S" || input != "Q")
                    {

                    }
                    else
                    {
                        validInput = true;
                    }
                }
                if (input == "S")
                {
                    Game game = new Game();
                    game.Start();
                }else
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to Dungeon Explorer");
            Console.WriteLine("Start a new game - S");
            Console.WriteLine("Quit game - Q");
            string input = Console.ReadLine();
            bool valid = false;
            while (valid == false)
            {
                if (input.ToUpper() == "S")
                {
                    Game game = new Game();
                    game.Start();
                }
                else if (input.ToUpper() == "Q")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
