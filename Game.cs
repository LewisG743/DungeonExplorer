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
            // Initialize the game with one room and one player
            Room room = new Room("Starting room. This room has nothing in it and is safe from enemies");
            currentRoom = room;

            player = new Player("Input", 100);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine("Welcome to Dungeon Explorer");
            Console.WriteLine("Room description: 1");
            Console.WriteLine("Search for doors: 2");
            Console.WriteLine("Scan for enemies: 3");
            Console.WriteLine("Search for items: 4");
            Console.WriteLine("Check inventory: 5");
            while (playing)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "2":
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
                    case "3":
                        if(currentRoom.hasEnemy)
                        {

                        }
                        else
                        {
                            Console.WriteLine("There is no enemy in this room");
                        }
                        break;
                    case "4":
                        if(currentRoom.GetItems().Count == 0)
                        {
                            Console.WriteLine("This room has no items in it");
                        }
                        else
                        {
                            Random rGen = new Random();
                            int random = rGen.Next(currentRoom.GetItems().Count - 1);
                            Console.WriteLine($"There is a {currentRoom.GetItems()[random].GetItemName()}");
                            Console.WriteLine("Would you like to pick it up? y/n");
                            string choice = Console.ReadLine();
                            if (choice.ToLower() != "y" && choice.ToLower() != "n")
                            {
                                Console.WriteLine("Invalid choice");
                            }
                            else if (choice.ToLower() == "y")
                            {
                                player.PickUpItem(currentRoom.GetItems()[random], currentRoom);
                                Console.WriteLine("Item has been added to your inventory");
                                player.InventoryContents();
                            }
                            else if (choice.ToLower() == "n")
                            {
                                Console.WriteLine($"{currentRoom.GetItems()[random].GetItemName()} has been put back down");
                            }
                        }
                        break;
                    case "5":
                        player.InventoryContents();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }
    }
}