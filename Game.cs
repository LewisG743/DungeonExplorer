using System;
using System.Linq;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialises the game with one room and one player
            Room room = new Room("Starting room. This room has nothing in it and is safe from enemies");
            currentRoom = room;

            player = new Player("", 100);
        }
        public void Start() // Starts the game flow
        {
            Console.WriteLine("Enter a name for your player");
            string name = Console.ReadLine();
            player.name = name;
            Console.WriteLine($"Your name is {player.name}");
            bool playing = true;
            Console.WriteLine("Welcome to Dungeon Explorer");
            Console.WriteLine("Room description: 1");
            Console.WriteLine("Search for doors: 2");
            Console.WriteLine("Scan for enemies: 3");
            Console.WriteLine("Search for items: 4");
            Console.WriteLine("Check inventory: 5");
            Console.WriteLine("Exit game: 6");
            Console.WriteLine("Change name: 7");
            while (playing) // Loops until playing has finished
            {
                switch (Console.ReadLine()) // Chooses the right case depending on what the player chooses
                {
                    case "1": // Displays the current rooms description
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "2": // Displays the doors in the room if there are any else says there are no doors
                        var doors = currentRoom.GetDoors();
                        int doorCount = doors.Count;

                        if (doorCount == 0)
                        {
                            Console.WriteLine("There are no doors in this room");
                        }
                        else
                        {
                            string doorMessage = "There are doors to the ";
                            doorMessage += string.Join(", ", doors.Take(doorCount - 1));

                            if (doorCount > 1)
                            {
                                doorMessage += " and " + doors.Last();
                            }
                            Console.WriteLine(doorMessage);
                        }
                        break;
                    case "3": // Checks if there is an enemy if not tells the user there are no enemies
                        if(currentRoom.hasEnemy)
                        {

                        }
                        else
                        {
                            Console.WriteLine("There is no enemy in this room");
                        }
                        break;
                    case "4": // Searchs the room for items
                        if(currentRoom.GetItems().Count == 0)
                        {
                            Console.WriteLine("This room has no items in it");
                        }
                        else
                        {
                            Random rGen = new Random();
                            int random = rGen.Next(currentRoom.GetItems().Count - 1); // Chooses a random item that is in the room
                            Console.WriteLine($"There is a {currentRoom.GetItems()[random].GetItemName()}");
                            Console.WriteLine("Would you like to pick it up? y/n");
                            string choice = Console.ReadLine();
                            if (choice.ToLower() != "y" && choice.ToLower() != "n") // Pickup item yes or no
                            {
                                Console.WriteLine("Invalid choice");
                            }
                            else if (choice.ToLower() == "y")
                            {
                                player.PickUpItem(currentRoom.GetItems()[random], currentRoom); // Picks up the item and removes it from the room
                                Console.WriteLine("Item has been added to your inventory");
                                player.InventoryContents(); // Displays the players inventory
                            }
                            else if (choice.ToLower() == "n") // Does not pickup the item
                            {
                                Console.WriteLine($"{currentRoom.GetItems()[random].GetItemName()} has been put back down");
                            }
                        }
                        break;
                    case "5": // Displays the players inventory contents
                        player.InventoryContents();
                        break;
                    case "6": // Exits the loop and ends the game
                        playing = false;
                        break;
                    case "7":
                        Console.WriteLine("Enter a new name");
                        player.name = Console.ReadLine();
                        Console.WriteLine($"Your new name is {player.name}");
                        break;
                    default: // Does nothing if not a valid option
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}