using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialises the game with one room and one player
            Room room = new Room("Starting room. This room has some items in it and one enemy hidden");
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
                        if(currentRoom.hasEnemy == true)
                        {
                            EnterBattle(currentRoom.GetEnemy(), player);
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

        private void EnterBattle(Enemy enemy, Player player)
        {
            bool hasRanAway = false;
            bool inBattle = true;
            Console.WriteLine($"A {enemy.name} has appeared");
            while (inBattle)
            {
                Console.WriteLine("What is your action");
                Console.WriteLine("Attack with a weapon: 1");
                Console.WriteLine("Use a potion: 2");
                Console.WriteLine("Run away: 3");
                Console.WriteLine($"{enemy.name} has {enemy.GetHealth()} health left");
                player.TakeDamage(enemy.GetDamage());
                Console.WriteLine($"The {enemy.name} has attacked you");
                Console.WriteLine($"You have {player.GetHealth()} health left");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (player.InventoryItems().Count == 0)
                        {
                            Console.WriteLine("You have no items");
                            break;
                        }
                        Console.WriteLine("Choose a weapon to attack with:");
                        List<string> temp1 = new List<string>();
                        for (int i = 1; i <= player.InventoryItems().Count; i++)
                        {
                            temp1.Add(i.ToString());
                        }
                        int count = 1;
                        foreach (Item x in player.InventoryItems())
                        {
                            Console.WriteLine($"{x.GetItemName()}: {count}");
                            count++;
                        }
                        bool valid1 = false;
                        while (!valid1)
                        {
                            string choice = Console.ReadLine();
                            if (!temp1.Contains(choice))
                            {
                                Console.WriteLine("Invalid input");
                            }
                            else
                            {
                                if (player.InventoryItems()[int.Parse(choice)-1] is Weapon)
                                {
                                    Weapon myWeapon = (Weapon)player.InventoryItems()[int.Parse(choice) - 1];
                                    enemy.TakeDamage(myWeapon.GetWeaponDamage());
                                    Console.WriteLine($"You have dealt {myWeapon.GetWeaponDamage()} damage to the {enemy.name}");
                                    valid1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Items chosen is not a weapon");
                                }
                            }
                        }
                        break;
                    case "2":
                        if (player.InventoryItems().Count == 0)
                        {
                            Console.WriteLine("You have no items");
                            break;
                        }
                        Console.WriteLine("Choose a potion to heal with:");
                        List<string> temp2 = new List<string>();
                        for (int i = 1; i <= player.InventoryItems().Count; i++)
                        {
                            temp2.Add(i.ToString());
                        }
                        count = 1;
                        foreach (Item x in player.InventoryItems())
                        {
                            Console.WriteLine($"{x.GetItemName()}: {count}");
                            count++;
                        }
                        bool valid2 = false;
                        while (!valid2)
                        {
                            string choice = Console.ReadLine();
                            if (!temp2.Contains(choice))
                            {
                                Console.WriteLine("Invalid input");
                            }
                            else
                            {
                                if (player.InventoryItems()[int.Parse(choice) - 1] is Potion)
                                {
                                    Potion myPotion = (Potion)player.InventoryItems()[int.Parse(choice) - 1];
                                    player.Heal(myPotion);
                                    Console.WriteLine($"You have healed {myPotion.GetHealthStored()} health");
                                    Console.WriteLine($"You now have {player.GetHealth()} health left");
                                    valid2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Items chosen is not a potion");
                                }
                            }
                        }
                        break;
                    case "3":
                        hasRanAway = true;
                        Console.WriteLine($"You run away from the {enemy.name}");
                        inBattle = false;
                        break;
                }
                if(enemy.GetHealth() <= 0)
                {
                    inBattle = false;
                }
            }
            if (hasRanAway)
            {
                return;
            }
            Item droppedItem = enemy.DropItem(currentRoom);
            currentRoom.SetItem(droppedItem);
            Console.WriteLine($"{enemy.name} has been defeated");
            Console.WriteLine($"{enemy.name} has dropped a {droppedItem.GetItemName()}");
            Console.WriteLine($"Would you like to pick up the {droppedItem.GetItemName()} y/n");
            currentRoom.HasEnemy(false);
            if (Console.ReadLine().ToLower() == "y")
            {
                player.PickUpItem(droppedItem, currentRoom);
                Console.WriteLine("Item has been picked up");
            }
            else if (Console.ReadLine().ToLower() == "n")
            {
                Console.WriteLine("Item has been dropped on the ground");
            }
        }
    }
}