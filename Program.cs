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
                string input = "";
                while (validInput == false)
                {
                    Console.WriteLine("while loop");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "S" || input.ToUpper() == "Q")
                    {
                        validInput = true;
                    }
                    else
                    {
                        
                    }
                }
                if (input.ToUpper() == "S")
                {
                    Game game = new Game();
                    game.Start();
                }
                else if (input.ToUpper() == "Q")
                {
                    break;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
